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

namespace InstaFashionShopping
{
    public partial class ProductView : System.Web.UI.Page
    {
        readonly Int32 myQty = 1;

        /*protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //Work and It will assign the values to label.
            divSuccess.Visible = true;

        }*/

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["PID"] != null)
                {
                    divSuccess.Visible = false;
                    BindProductDetails();
                    BindProductImage();
                    BindMap();
                }
            }
        }
        /// <summary>
        /// This method adds the selected item to the cart for further processing .
        /// </summary>
        private void AddToCartProduction(string sizeName,int sizeId)
        {
            if (Session["USERID"] != null)
            {
                Int32 UserID = Convert.ToInt32(Session["USERID"].ToString());
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                Int32 SizeID = sizeId;
                string SizeName = sizeName;
                using (SqlConnection con = new SqlConnection(Utility.ConnString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_IsProductExistInCart", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@SizeID", SizeID);
                    cmd.Parameters.AddWithValue("@PID", PID);

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Int32 updateQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                            SqlCommand myCmd = new SqlCommand("SP_UpdateCart1", con)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            myCmd.Parameters.AddWithValue("@Quantity", updateQty + 1);
                            myCmd.Parameters.AddWithValue("@CartPID", PID);
                            myCmd.Parameters.AddWithValue("@UserID", UserID);
                            myCmd.Parameters.AddWithValue("@SizeID", SizeID);
                            Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                            divSuccess.Visible = true;
                        }
                        else
                        {
                            SqlCommand myCmd = new SqlCommand("SP_InsertCart", con)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            myCmd.Parameters.AddWithValue("@UID", UserID);
                            myCmd.Parameters.AddWithValue("@PID", Session["CartPID"].ToString());
                            myCmd.Parameters.AddWithValue("@PName", Session["myPName"].ToString());
                            myCmd.Parameters.AddWithValue("@PPrice", Session["myPPrice"].ToString());
                            myCmd.Parameters.AddWithValue("@PSelPrice", Session["myPSelPrice"].ToString());
                            myCmd.Parameters.AddWithValue("@SizeID", SizeID);
                            myCmd.Parameters.AddWithValue("@Qty", myQty);
                            Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                            con.Close();
                            divSuccess.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                Response.Redirect("login.aspx?rurl=" + PID);
            }
        }
        private void BindMap()
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                SqlCommand cmd = new SqlCommand("Select p.PName,g.GenderName from Products p INNER JOIN Gender g ON g.GenderID = p.PGender where PID='" + PID + "'", con)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@PID", PID);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrmap.DataSource = dt;
                    rptrmap.DataBind();
                    Session["myPName"] = dt.Rows[0]["PName"].ToString();
                    Session["Gender"] = dt.Rows[0]["GenderName"].ToString();
                }
            }
        }
        
        /// <summary>
        /// This function binds the product data to the selected product from the page 
        /// /// </summary>
        private void BindProductDetails()
        {
           
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindProductDetails", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@PID", PID);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrProductDetails.DataSource = dt;
                    rptrProductDetails.DataBind();
                    Session["CartPID"] = Convert.ToInt32(dt.Rows[0]["PID"].ToString());
                    Session["myPName"] = dt.Rows[0]["PName"].ToString();
                    Session["myPPrice"] = dt.Rows[0]["PPrice"].ToString();
                    Session["myPSelPrice"] = dt.Rows[0]["PSelPrice"].ToString();
                    Session["mySizeID"] = dt.Rows[0]["SizeID"].ToString();
                }

            }
        }

        private void BindProductImage()
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from ProductImages where PID='" + PID + "'", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrImage.DataSource = dt;
                        rptrImage.DataBind();
                    }
                }
            }
        }
        protected string GetActiveImgClass(int index)
        {
            if (index == 0)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }


        protected void rptrProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RadioButtonList rblSize = e.Item.FindControl("rblSize") as RadioButtonList;
                using (SqlConnection con = new SqlConnection(Utility.ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT s.SizeName,s.SizeID,pqs.Quantity FROM Products p  INNER JOIN ProductSizeQuantity pqs ON pqs.PID=p.PID  INNER JOIN Size s ON s.SizeID=pqs.SizeID  where pqs.PID ='" + PID + "'", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = reader["SizeName"].ToString();
                            item.Value = reader["SizeID"].ToString();
                            rblSize.Items.Add(item);
                        }

                        reader.Close();
                    }
                    con.Close();
                }
            }
        }

        protected void btnAddtoCart_Click(object sender, EventArgs e)
        {
            int SelectedSizeID = 0;
            string SelectedSizeName = string.Empty;
            
            if (Session["USERID"] != null)
            {
                foreach (RepeaterItem item in rptrProductDetails.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var rbList = item.FindControl("rblSize") as RadioButtonList;

                        if(rbList.SelectedItem != null)
                        { 
                            SelectedSizeName = rbList.SelectedItem.Text as string;
                            SelectedSizeID = Convert.ToInt32(rbList.SelectedItem.Value);
                            var lblError =  item.FindControl("lblError") as Label;
                            lblError.Text = "";
                        }
                    }
                }

                if (SelectedSizeName != "")
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                    if (Request.Cookies["CartPID"] != null)
                    {
                        string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                        CookiePID = CookiePID + "," + PID + "-" + SelectedSizeID;
                        HttpCookie CartProducts = new HttpCookie("CartPID");
                        CartProducts.Values["CartPID"] = CookiePID;
                        CartProducts.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(CartProducts);
                       
                    }
                    else
                    {
                        HttpCookie CartProducts = new HttpCookie("CartPID");
                        CartProducts.Values["CartPID"] = PID.ToString() + "-" + SelectedSizeID;
                        CartProducts.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(CartProducts);
                    }

                    AddToCartProduction(SelectedSizeName, SelectedSizeID);
                    Response.Write("<script>alert('Product Added To cart SuccessFully')</script>");
                    Response.Write("<script>window.location = '" + Request.RawUrl + "'</script>");
                }
                else
                {
                    foreach (RepeaterItem item in rptrProductDetails.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            Response.Write("<script>alert('Please Select Size')</script>");
                            Response.Write("<script>window.location = '" + Request.RawUrl + "'</script>");
                        }
                    }

                }
            }
            else
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                Response.Redirect("login.aspx?rurl=" + PID);
            }
        }
        protected override void InitializeCulture()
        {
            CultureInfo ci = new CultureInfo("en-IN");
            ci.NumberFormat.CurrencySymbol = "₹";
            Thread.CurrentThread.CurrentCulture = ci;

            base.InitializeCulture();
        }

        protected void btnAddtoWishlist_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(Session["USERID"]); 
                int productId = Convert.ToInt32(Request.QueryString["PID"]); 

                using (SqlConnection con = new SqlConnection(Utility.ConnString))
                {
                    con.Open();

                    // Checking if the product is already in the wishlist
                    string query = "SELECT COUNT(*) FROM Wishlist WHERE uid = @uid AND pid = @pid";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@uid", userId);
                        cmd.Parameters.AddWithValue("@pid", productId);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            Response.Write("<script>alert('Product is already in the wishlist.')</script>");
                            return;

                        }
                    }

                    // Inserting the product into the wishlist
                    query = "INSERT INTO Wishlist (uid, pid) VALUES (@uid, @pid)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@uid", userId);
                        cmd.Parameters.AddWithValue("@pid", productId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Product added to wishlist successfully.')</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred while adding the product to the wishlist. " + ex.Message + "')</script>");
            }
        }

        protected void rptrProductDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToWishlist")
            {
                ImageButton btn = e.Item.FindControl("btnAddtoWishlist") as ImageButton;
                btn.ImageUrl = "~/imgs/HeartRed.png";
            }

            e.Item.DataBind();
        }
    }
}
