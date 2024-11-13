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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Uname"] != null && Request.Cookies["Upass"] != null)
                {
                    TextBox1.Text = Request.Cookies["Uname"].Value;
                    TextBox2.Text = Request.Cookies["Upass"].Value;
                    CheckBox1.Checked = true;
                }

                if(Convert.ToString(Request.QueryString["rurl"]) == null)
                {
                    Response.Write("<script>alert('Please Login')</script>");
                }
            }
        }

        /// <summary>
        /// Login Event to check Password function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSignIn_click(object sender, EventArgs e)
        {
            using (
           SqlConnection con = new SqlConnection(@"Data Source=ANNAPURNA\SQLAnna;Initial Catalog=Insta-FashionDB;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from users where Username=@username and Password=@password", con);
                cmd.Parameters.AddWithValue("@username", TextBox1.Text);
                cmd.Parameters.AddWithValue("@password", Cryptography.Encrypt(Convert.ToString(TextBox2.Text)));
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    Session["USERID"] = dt.Rows[0]["User_id"].ToString();
                    Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();
                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);
                    if (CheckBox1.Checked)
                    {
                        Response.Cookies["Uname"].Value = TextBox1.Text;
                        Response.Cookies["Upass"].Value = TextBox2.Text;
                        Response.Cookies["Uname"].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies["Upass"].Expires = DateTime.Now.AddDays(1);
                    }
                    else
                    {
                        Response.Cookies["Uname"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Upass"].Expires = DateTime.Now.AddDays(-1);
                    }
                    string Utype;
                    Utype = dt.Rows[0][6].ToString().Trim();
                    if (Utype == "User")
                    {
                        Session["Username"] = TextBox1.Text;
                        Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();
                        Response.Redirect("~/UserHome.aspx");
                        Session["LoginType"] = "User";
                        if (Request.QueryString["rurl"] != null)
                        {
                            if (Request.QueryString["rurl"] == "cart")
                            {
                                Response.Redirect("Cart.aspx");
                            }

                            if (Request.QueryString["rurl"] == "PID")
                            {
                                string myPID = Session["ReturnPID"].ToString();
                                Response.Redirect("ProductView.aspx?PID=" + myPID + "");
                            }
                        }
                        else
                        {
                            Response.Redirect("UserHome.aspx?UserLogin=YES");
                        }
                    }
                    if (Utype == "Admin")
                    {
                        Session["Username"] = TextBox1.Text;
                        Session["LoginType"] = "Admin";
                        Response.Redirect("~/AdminHome.aspx");
                    }
                }
                else
                {
                    Label1.Text = "Invalid Credentials";
                }
                clr();
                con.Close();
            }

        }
        private void clr()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox1.Focus();

        }
    }
}