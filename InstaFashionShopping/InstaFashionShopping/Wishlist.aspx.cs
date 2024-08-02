using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Web.UI.HtmlControls;

namespace InstaFashionShopping
{
    public partial class Wishlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USERID"] != null)
                {
                    BindProductRepeater();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }
        private void BindProductRepeater()
        {
            int userId = Convert.ToInt32(Session["USERID"]);
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT p.*,i.*,p.PPrice-p.PSelPrice as DiscAmount,I.Name as ImageName,b.Name as BrandName FROM Wishlist w INNER JOIN Products p ON p.PID = w.PID INNER JOIN Brand b ON b.BrandId = p.PBrandId INNER JOIN Users u ON u.user_id = w.UID cross apply(select top 1 * from ProductImages I where I.PID = P.PID order by i.PID desc )i WHERE u.user_id = @userId", con))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrWishlist.DataSource = dt;
                        rptrWishlist.DataBind();
                        if (dt.Rows.Count <= 0)
                        {
                            Label1.Text = "No Products in Your Wishlist";
                        }
                        else
                        {
                            Label1.Text = "My Wishlist";
                        }
                    }
                }
            }
        }

        protected void rptrWishlist_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "RemoveFromWishlist")
            {
                int userId = Convert.ToInt32(Session["USERID"]);
                int productId = Convert.ToInt32(e.CommandArgument);

                // Remove the product from the wishlist
                using (SqlConnection con = new SqlConnection(Utility.ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Wishlist WHERE UID = @userId AND PID = @productId", con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@productId", productId);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        con.Close();

                        if (result > 0)
                        {
                            BindProductRepeater();
                        }
                    }
                }
                Response.Write("<script>alert('Product Removed From WishList.')</script>");
            }

            if (e.CommandName == "Addtocart")
            {
                string pid = e.CommandArgument.ToString();
                Response.Redirect("ProductView.aspx?pid=" + pid);
                
            }
        }
    }
}
