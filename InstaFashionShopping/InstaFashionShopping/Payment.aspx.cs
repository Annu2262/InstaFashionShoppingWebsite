using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace InstaFashionShopping
{
    public partial class Payment : System.Web.UI.Page
    {
        public static Int32 OrderNumber = 1;
        public SqlDataReader sdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERNAME"] != null)
            {
                if (!IsPostBack)
                {
                    BindPriceData();
                    SqlDataReader sdr = BindUserDetails();
                    genAutoNum();
                    BindOrderProducts();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
        public SqlDataReader BindUserDetails()
        {
            SqlConnection con = new SqlConnection(Utility.ConnString);
            con.Open();
            string query = "select * from users where username = '" + Session["Username"] + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtName.Text = sdr["full_name"].ToString();
                txtMobileNumber.Text = sdr["phone"].ToString();
                txtAddress.Text = sdr["address"].ToString();

            }
            con.Close();

            return sdr;
        }
        private void BindPriceData()
        {
            string UserIDD = Session["USERID"].ToString();
            ConFee.InnerText = "Free";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindPriceData", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("UserID", UserIDD);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string Total = dt.Compute("Sum(SubSAmount)", "").ToString();
                        string CartTotal = dt.Compute("Sum(SubPAmount)", "").ToString();
                        string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                        int Total1 = Convert.ToInt32(dt.Compute("Sum(SubSAmount)", ""));
                        int CartTotal1 = Convert.ToInt32(dt.Compute("Sum(SubPAmount)", ""));
                        spanTotal.InnerText = "Rs. " + string.Format("{0:#,###.##}", double.Parse(Total)) + ".00";
                        Session["myCartAmount"] = string.Format("{0:####}", double.Parse(Total));
                        spanCartTotal.InnerText = "Rs. " + string.Format("{0:#,###.##}", double.Parse(CartTotal)) + ".00";
                        spanDiscount.InnerText = "- Rs. " + (CartTotal1 - Total1).ToString();
                        Session["TotalAmount"] = spanTotal.InnerText;
                        hdCartAmount.Value = CartTotal.ToString();
                        hdCartDiscount.Value = (CartTotal1 - Total1).ToString() + ".00";
                        hdTotalPayed.Value = Total.ToString();
                    }
                    else
                    {
                        Response.Redirect("Products.aspx");
                    }
                }
            }
        }
        private void genAutoNum()
        {
            Random r = new Random();
            int num = r.Next(Convert.ToInt32("231965"),
            Convert.ToInt32("987654"));
            string ChkOrderNum = num.ToString();
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                SqlCommand cmd = new SqlCommand("SP_FindOrderNumber", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FindOrderNumber", ChkOrderNum);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count > 0)
                    {
                        genAutoNum();
                    }
                    else
                    {
                        OrderNumber = Convert.ToInt32(num.ToString());
                    }
                }
            }
        }
        private void BindOrderProducts()
        {
            string UserIDD = Session["USERID"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection con0 = new SqlConnection(Utility.ConnString))
            {
                SqlCommand cmd0 = new SqlCommand("SP_BindCartProducts", con0)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd0.Parameters.AddWithValue("@UID", UserIDD);
                using (SqlDataAdapter sda0 = new SqlDataAdapter(cmd0))
                {
                    sda0.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataColumn PID in dt.Columns)
                        {
                            using (SqlConnection con = new SqlConnection(Utility.ConnString))
                            {
                                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Cart C WHERE C.PID=" + PID + " AND UID ='" + UserIDD + "'", con))
                                {
                                    cmd.CommandType = CommandType.Text;
                                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                    {
                                        DataTable dtProducts = new DataTable();
                                        sda.Fill(dtProducts);
                                        gvProducts.DataSource = dtProducts;
                                        gvProducts.DataBind();
                                    }
                                }
                            }
                        }
                    }
                    EmptyCart();
                }
            }
        }
        //private void InsertOrderProducts()
        //{
        //    string USERID = Session["USERID"].ToString();
        //    using (SqlConnection con = new SqlConnection(Utility.ConnString))
        //    {
        //        foreach (GridViewRow gvr in gvProducts.Rows)
        //        {
        //            SqlCommand myCmd = new SqlCommand("SP_InsertOrderProducts", con)
        //            {
        //                CommandType = CommandType.StoredProcedure
        //            };
        //            myCmd.Parameters.AddWithValue("@OrderID", OrderNumber.ToString());
        //            myCmd.Parameters.AddWithValue("@UserID", USERID);
        //            myCmd.Parameters.AddWithValue("@PID", gvr.Cells[0].Text);
        //            myCmd.Parameters.AddWithValue("@Products", gvr.Cells[1].Text);
        //            myCmd.Parameters.AddWithValue("@SizeID", gvr.Cells[2].Text);
        //            myCmd.Parameters.AddWithValue("@Quantity", gvr.Cells[3].Text);
        //            myCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString("yyyy-MM-dd"));
        //            myCmd.Parameters.AddWithValue("@Status", "Pending");
        //            if (con.State == ConnectionState.Closed) { con.Open(); }
        //            Int64 OrderProID = Convert.ToInt64(myCmd.ExecuteScalar());
        //            con.Close();
        //        }
        //        EmptyCart();
        //        Response.Redirect("Success.aspx");
        //    }
        //}


        private void InsertOrderProducts()
        {
            string userId = Session["USERID"].ToString();
            using (SqlConnection connection = new SqlConnection(Utility.ConnString))
            {
                connection.Open();
                foreach (GridViewRow row in gvProducts.Rows)
                {
                    string productId = row.Cells[0].Text;
                    string sizeId = row.Cells[2].Text;

                    // Check if the order product already exists in the database
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM OrderProducts WHERE OrderID = @OrderID AND UserID = @UserID AND PID = @PID AND SizeID = @SizeID", connection);
                    checkCmd.Parameters.AddWithValue("@OrderID", OrderNumber.ToString());
                    checkCmd.Parameters.AddWithValue("@UserID", userId);
                    checkCmd.Parameters.AddWithValue("@PID", productId);
                    checkCmd.Parameters.AddWithValue("@SizeID", sizeId);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0) // If the order product already exists, display an error message and stop further processing
                    {
                        Response.Write("<script>alert('The selected order product already exists in your order.')</script>");
                        Response.Write("<script>window.location = '" + "Cart.aspx" + "'</script>");
                        return;
                    }

                    // Insert the order product into the database
                    SqlCommand insertCmd = new SqlCommand("SP_InsertOrderProducts", connection);
                    insertCmd.CommandType = CommandType.StoredProcedure;
                    insertCmd.Parameters.AddWithValue("@OrderID", OrderNumber.ToString());
                    insertCmd.Parameters.AddWithValue("@UserID", userId);
                    insertCmd.Parameters.AddWithValue("@PID", productId);
                    insertCmd.Parameters.AddWithValue("@Products", row.Cells[1].Text);
                    insertCmd.Parameters.AddWithValue("@SizeID", sizeId);
                    insertCmd.Parameters.AddWithValue("@Quantity", row.Cells[3].Text);
                    insertCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    insertCmd.Parameters.AddWithValue("@Status", "Pending");
                    insertCmd.ExecuteNonQuery();

                    //Decrease the Product Quantity from the database
                    SqlCommand updateCmd = new SqlCommand("UPDATE ProductSizeQuantity SET Quantity = Quantity - @Quantity WHERE PID = @PID AND SizeID = @SizeID", connection);
                    updateCmd.Parameters.AddWithValue("@Quantity", row.Cells[3].Text);
                    updateCmd.Parameters.AddWithValue("@PID", productId);
                    updateCmd.Parameters.AddWithValue("@SizeID", sizeId);
                    updateCmd.ExecuteNonQuery();
                }

                EmptyCart();
                //// Send an email to the user confirming the order has been placed
                //string toEmail = "user@example.com"; // replace with the user's email address
                //string subject = "Order Placed Successfully";
                //string body = "Dear User,<br/><br/>Your order has been successfully placed with the following details:<br/>Order ID: " + OrderNumber.ToString() + "<br/>";

                //// Add the product details to the email body
                //foreach (GridViewRow row in gvProducts.Rows)
                //{
                //    string productName = row.Cells[1].Text;
                //    string price = row.Cells[2].Text;
                //    int quantity = Convert.ToInt32(row.Cells[3].Text);
                //    body += productName + " x " + quantity + " @ Rs" + price + " = Rs" + (quantity * Convert.ToDecimal(price)) + "<br/>";
                //}
                ////Calculating Total Amount
                //decimal totalAmount = 0;
                //foreach (GridViewRow row in gvProducts.Rows)
                //{
                //    decimal price = Convert.ToDecimal(row.Cells[2].Text);
                //    int quantity = Convert.ToInt32(row.Cells[3].Text);
                //    totalAmount += price * quantity;
                //}

                //// Add the total amount to the email body
                //body += "Total Amount: Rs" + totalAmount + "<br/><br/>Thank you for shopping with us!<br/>";

                //MailMessage mailMessage = new MailMessage();
                //mailMessage.From = new MailAddress("Insta Fashion <annapurnag2262@gmail.com>");
                //mailMessage.To.Add(new MailAddress(toEmail));
                //mailMessage.Subject = subject;
                //mailMessage.Body = body;
                //mailMessage.IsBodyHtml = true;

                //SmtpClient smtpClient = new SmtpClient();
                //smtpClient.Host = "smtp.gmail.com";
                //smtpClient.Port = 587;
                //smtpClient.EnableSsl = true;
                //smtpClient.UseDefaultCredentials = false;
                //smtpClient.Credentials = new NetworkCredential("annapurnag2262@gmail.com", "gfczyeolckbodqis");

                //smtpClient.Send(mailMessage);

                Response.Redirect("Success.aspx");
            }
        }
        private string GetUserEmail(int userId)
        {
            string email = "";
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                SqlCommand cmd = new SqlCommand("SELECT email FROM Users WHERE username = @username");
                {
                    cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        email = result.ToString();
                    }
                }
            }
            return email;
        }
        private void EmptyCart()
        {
            Int32 CartUIDD = Convert.ToInt32(Session["USERID"].ToString());
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                SqlCommand cmdU = new SqlCommand("SP_EmptyCart", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmdU.Parameters.AddWithValue("@UserID", CartUIDD);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                cmdU.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void btncardchcekout_Click(object sender, EventArgs e)
        {

            if (Session["Username"] != null)
            {
                Session["Address"] = txtAddress.Text;
                Session["Mobile"] = txtMobileNumber.Text;
                Session["OrderNumber"] = OrderNumber.ToString();
                Session["PayMethod"] = "Card";

                string USERID = Session["USERID"].ToString();
                string PaymentType = "Card";
                string PaymentStatus = "Paid";
                string EMAILID = Session["USEREMAIL"].ToString();
                string OrderStatus = "Pending";
                string FullName = txtName.Text;
                using (SqlConnection con = new SqlConnection(Utility.ConnString))
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", USERID);
                    cmd.Parameters.AddWithValue("@Email", EMAILID);
                    cmd.Parameters.AddWithValue("@CartAmount", hdCartAmount.Value);
                    cmd.Parameters.AddWithValue("@CartDiscount", hdCartDiscount.Value);
                    cmd.Parameters.AddWithValue("@TotalPaid", hdTotalPayed.Value);
                    cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
                    cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                    cmd.Parameters.AddWithValue("@DateOfPurchase", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Name", FullName);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@MobileNumber", txtMobileNumber.Text);
                    cmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);
                    cmd.Parameters.AddWithValue("@OrderNumber", OrderNumber.ToString());
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    Int64 OrderID = Convert.ToInt64(cmd.ExecuteScalar());

                    InsertOrderProducts();
                    
                    BindOrderProducts();
                }
            }
            else
            {
                Response.Redirect("SignIn.aspx?RtPP=yes");
            }
        }

        protected void btnchceckoutcod_Click(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Session["Address"] = txtAddress.Text;
                Session["Mobile"] = txtMobileNumber.Text;
                Session["OrderNumber"] = OrderNumber.ToString();
                Session["PayMethod"] = "COD";

                string USERID = Session["USERID"].ToString();
                string PaymentType = "Card";
                string PaymentStatus = "Pending";
                string EMAILID = Session["USEREMAIL"].ToString();
                string OrderStatus = "Pending";
                string FullName = txtName.Text;
                using (SqlConnection con = new SqlConnection(Utility.ConnString))
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", USERID);
                    cmd.Parameters.AddWithValue("@Email", EMAILID);
                    cmd.Parameters.AddWithValue("@CartAmount", hdCartAmount.Value);
                    cmd.Parameters.AddWithValue("@CartDiscount", hdCartDiscount.Value);
                    cmd.Parameters.AddWithValue("@TotalPaid", hdTotalPayed.Value);
                    cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
                    cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                    cmd.Parameters.AddWithValue("@DateOfPurchase", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Name", FullName);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@MobileNumber", txtMobileNumber.Text);
                    cmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);
                    cmd.Parameters.AddWithValue("@OrderNumber", OrderNumber.ToString());
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    Int64 OrderID = Convert.ToInt64(cmd.ExecuteScalar());
                    
                    InsertOrderProducts();
                    
                }
            }
            else
            {
                Response.Redirect("SignIn.aspx?RtPP=yes");
            }
        }

        protected void btncardchceckout_Click(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Session["Address"] = txtAddress.Text;
                Session["Mobile"] = txtMobileNumber.Text;
                Session["OrderNumber"] = OrderNumber.ToString();
                Session["PayMethod"] = "Card";

                string USERID = Session["USERID"].ToString();
                string PaymentType = "Card";
                string PaymentStatus = "Paid";
                string EMAILID = Session["USEREMAIL"].ToString();
                string OrderStatus = "Pending";
                string FullName = txtName.Text;
                using (SqlConnection con = new SqlConnection(Utility.ConnString))
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", USERID);
                    cmd.Parameters.AddWithValue("@Email", EMAILID);
                    cmd.Parameters.AddWithValue("@CartAmount", hdCartAmount.Value);
                    cmd.Parameters.AddWithValue("@CartDiscount", hdCartDiscount.Value);
                    cmd.Parameters.AddWithValue("@TotalPaid", hdTotalPayed.Value);
                    cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
                    cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                    cmd.Parameters.AddWithValue("@DateOfPurchase", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Name", FullName);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@MobileNumber", txtMobileNumber.Text);
                    cmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);
                    cmd.Parameters.AddWithValue("@OrderNumber", OrderNumber.ToString());
                    if (con.State == ConnectionState.Closed) { con.Open(); }
                    Int64 OrderID = Convert.ToInt64(cmd.ExecuteScalar());
                    InsertOrderProducts();
                    BindOrderProducts();
                }
            }
            else
            {
                Response.Redirect("SignIn.aspx?RtPP=yes");
            }
        }
    }
}
