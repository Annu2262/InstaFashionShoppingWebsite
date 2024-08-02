using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace InstaFashionShopping
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        String GUIDvalue;

        int Uid;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
            {

                GUIDvalue = Request.QueryString["Uid"];

                if (GUIDvalue != null)
                {
                    SqlCommand cmd = new SqlCommand("Select * from ForgotPass where Id=@Id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", GUIDvalue);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    sda.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        Uid = Convert.ToInt32(dt.Rows[0][1]);
                    }
                    else
                    {
                        Label1.Text = "Your Password Reset Link is Expired or Invalid...try again";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }

                }
                else
                {
                    Response.Redirect("~/SignIn.aspx");
                }


            }

            if (!IsPostBack)
            {
                if (dt.Rows.Count != 0)
                {
                    TextBox2.Visible = true;
                    TextBox1.Visible = true;
                    Button1.Visible = true;
                }
                else
                {
                    Label1.Text = "Your Password Reset Link is Expired or Invalid...try again";
                    Label1.ForeColor = System.Drawing.Color.Red;

                }

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox1.Text == TextBox2.Text)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update tblUsers set Password=@p where Uid=@Uid", con);
                    cmd.Parameters.AddWithValue("@p", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Uid", Uid);
                    cmd.ExecuteNonQuery();


                    SqlCommand cmd2 = new SqlCommand("delete form ForgotPass where Uid='" + Uid + "'", con);
                    cmd2.ExecuteNonQuery();
                    Response.Write("<script> alert('Password Reset Successfully done');  </script>");
                    Response.Redirect("~/SignIn.aspx");
                }
            }
        }
    }
}