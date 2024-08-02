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
    public partial class Cart : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            divQtyError.Visible = false;
            if (!IsPostBack)
            {
                if (Session["USERID"] != null)
                {
                    BindProductCart();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        private void BindProductCart()
        {
            int userId = Convert.ToInt32(Session["USERID"]);
            string UserIDD = Session["USERID"].ToString();

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindUserCart", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserID", UserIDD);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    rptrCartProducts.DataSource = dt;
                    rptrCartProducts.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        string Total = dt.Compute("Sum(SubSAmount)", "").ToString();
                        string CartTotal = dt.Compute("Sum(SubPAmount)", "").ToString();
                        string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                        h4NoItems.InnerText = "My Cart ( " + CartQuantity + " Item(s) )";
                        int Total1 = Convert.ToInt32(dt.Compute("Sum(SubSAmount)", ""));
                        int CartTotal1 = Convert.ToInt32(dt.Compute("Sum(SubPAmount)", ""));
                        spanTotal.InnerText = "Rs. " + string.Format("{0:#,###.##}", double.Parse(Total)) + ".00";
                        spanCartTotal.InnerText = "Rs. " + string.Format("{0:#,###.##}", double.Parse(CartTotal)) + ".00";
                        spanDiscount.InnerText = "- Rs. " + (CartTotal1 - Total1).ToString() + ".00";
                        ConFee.InnerText = "Free";
                    }
                    else
                    {
                        h4NoItems.InnerText = "Your Shopping Cart is Empty.";
                        divAmountSect.Visible = false;

                    }
                }
            }
        }
        protected void rptrCartProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Int32 UserID = Convert.ToInt32(Session["USERID"].ToString());
            //This will add +1 to current quantity using PID and SizeID
            if (e.CommandName == "DoPlus")
            {
                string PID = (e.CommandArgument.ToString());
                HtmlInputText txtSizeBoc = e.Item.FindControl("pSizeId") as HtmlInputText;
                Int32 valSizeId = Convert.ToInt16(txtSizeBoc.Value);

                using (SqlConnection con = new SqlConnection(Utility.ConnString))
                {
                    SqlCommand cmd = new SqlCommand("SP_getUserCartItem", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@PID", PID);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@SizeID", valSizeId);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Int32 updateQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                            if (updateQty < 5) // limit to 5
                            {
                                SqlCommand myCmd = new SqlCommand("SP_UpdateCart", con)
                                {
                                    CommandType = CommandType.StoredProcedure
                                };
                                myCmd.Parameters.AddWithValue("@Quantity", updateQty + 1);
                                myCmd.Parameters.AddWithValue("@CartPID", PID);
                                myCmd.Parameters.AddWithValue("@UserID", UserID);
                                myCmd.Parameters.AddWithValue("@SizeID", valSizeId);
                                con.Open();
                                Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                                con.Close();
                                BindProductCart();
                            }
                            else
                            {
                                
                            }
                        }
                    }
                }
            }

            else if (e.CommandName == "DoMinus")
            {
                string PID = (e.CommandArgument.ToString());
                HtmlInputText txtSizeBoc = e.Item.FindControl("pSizeId") as HtmlInputText;
                Int32 valSizeId = Convert.ToInt16(txtSizeBoc.Value);

                using (SqlConnection con = new SqlConnection(Utility.ConnString))
                {
                    SqlCommand cmd = new SqlCommand("SP_getUserCartItem", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@PID", PID);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@SizeID", valSizeId);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Int32 myQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                            if (myQty <= 1)
                            {
                                divQtyError.Visible = true;
                            }
                            else
                            {
                                SqlCommand myCmd = new SqlCommand("SP_UpdateCart", con)
                                {
                                    CommandType = CommandType.StoredProcedure
                                };
                                myCmd.Parameters.AddWithValue("@Quantity", myQty - 1);
                                myCmd.Parameters.AddWithValue("@CartPID", PID);
                                myCmd.Parameters.AddWithValue("@UserID", UserID);
                                myCmd.Parameters.AddWithValue("@SizeID", valSizeId);
                                con.Open();
                                Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                                con.Close();
                                BindProductCart();
                            }
                        }
                    }
                }
            }
            else if (e.CommandName == "RemoveThisCart")
            {
                int CartPID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                HtmlInputText txtSizeBoc = e.Item.FindControl("pSizeId") as HtmlInputText;
                Int32 valSizeId = Convert.ToInt16(txtSizeBoc.Value);
                HtmlInputText txtPIDBoc = e.Item.FindControl("txtPID") as HtmlInputText;
                Int32 valPId = Convert.ToInt32(txtPIDBoc.Value);

                using (SqlConnection con = new SqlConnection(Utility.ConnString))
                {
                    SqlCommand myCmd = new SqlCommand("SP_DeleteThisCartItem", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    myCmd.Parameters.AddWithValue("@CartID", CartPID);
                    con.Open();
                    myCmd.ExecuteNonQuery();
                    con.Close();
                    BindProductCart();


                    string CookiePIDActual = Request.Cookies["CartPID"].Value.Split('=')[1];
                    string CookiePIDTemp = valPId + "-" + valSizeId;

                    string[] ProductArray = CookiePIDActual.Split(',');

                    int numIndex = Array.IndexOf(ProductArray, CookiePIDTemp);
                    ProductArray = ProductArray.Where((val, idx) => idx != numIndex).ToArray();

                    var prodJoin = String.Join(",", ProductArray);

                    HttpCookie CartProducts = new HttpCookie("CartPID");
                    CartProducts.Values["CartPID"] = prodJoin;
                    CartProducts.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(CartProducts);
                    Response.Redirect(Request.RawUrl);

                }
            }
        }
        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx");
        }
    }
}