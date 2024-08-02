using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace InstaFashionShopping
{
    public partial class User : System.Web.UI.MasterPage
    {
        public static String CS = ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindCartNumber();
            BindCartNumberBasedOnUserId();
        }
        /// <summary>
        /// Checks for items in the cookies
        /// </summary>
        public void BindCartNumber()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] ProductArray = CookiePID.Split(',');
                int ProductCount = Utility.ProdCount(ProductArray);
                CartBadge.InnerText = ProductCount.ToString();
            }
            else
            {
               
                BindCartNumberBasedOnUserId();
            }
        }

        /// <summary>
        /// This function checks if the userid is not null . This function is used when the cookies data is null.
        /// </summary>
        public void BindCartNumberBasedOnUserId()
        {
            if (Session["USERID"] != null)
            {
                string UserIDD = Session["USERID"].ToString();
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(Utility.ConnString))
                {
                    SqlCommand cmd = new SqlCommand("SP_BindCartNumberz", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@UserID", UserIDD);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string CartQuantity = Convert.ToString(dt.Rows.Count);// dt.Compute("Sum(Qty)", "").ToString();
                            CartBadge.InnerText = CartQuantity;

                        }
                        else
                        {
                            CartBadge.InnerText = Convert.ToString(0);
                        }
                    }
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session["Username"] = null;
            Response.Redirect("Default.aspx");        }
    }

}
