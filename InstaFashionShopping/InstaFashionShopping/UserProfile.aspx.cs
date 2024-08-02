using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace InstaFashionShopping
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    getdetails();
                }
            }
        }
        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session["Username"] = null;
            Response.Redirect("Default.aspx");
        }
        public void getdetails()
        {
            SqlConnection con = new SqlConnection(Utility.ConnString);
            con.Open();
            string query = "select * from users where username = '" + Session["Username"] + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtfname.Text = dr["full_name"].ToString();
                lblname.Text= dr["full_name"].ToString();
                txtphone.Text = dr["phone"].ToString();
                txtuname.Text = dr["username"].ToString();
                txtemail.Text = dr["email"].ToString();
                
            }
            con.Close();

        }
        public void updatedetails()
        {
            SqlConnection con = new SqlConnection(Utility.ConnString);
            con.Open();
            string query = "update users set full_name=@uname,email=@email,username=@username,phone=@phone,address=@add where username=@login";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@uname", txtfname.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@username", txtuname.Text);
            cmd.Parameters.AddWithValue("@phone", txtphone.Text);
            cmd.Parameters.AddWithValue("@add", txtadd.Text);
            cmd.Parameters.AddWithValue("@login", Session["Username"]);

            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                getdetails();
                Response.Write("<script>alert('Data Has Been Updated Successfully')</script>");
                
            }
            con.Close();
        }
        protected void update_Click(object sender, EventArgs e)
        {
            updatedetails();
        }

        protected void btnupadatepass_Click(object sender, EventArgs e)
        {
            string username = Session["Username"].ToString();

            // Get the old password entered by the user
            string oldPassword = txtoldpass.Text;

            // Get the new password entered by the user
            string newPassword = txtnewpass.Text;

            // Check if the new password matches the confirm password
            if (newPassword != txtconfpass.Text)
            {
                lblMessage.Text = "New password and confirm password do not match.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Connect to the database
            SqlConnection con = new SqlConnection(Utility.ConnString);
            {
                con.Open();

                // Check if the old password entered by the user matches the password stored in the database
                string sql = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", Cryptography.Encrypt(oldPassword));
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();
                    sql = "UPDATE Users SET Password = @NewPassword WHERE Username = @Username";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@NewPassword", Cryptography.Encrypt(newPassword));
                    cmd.Parameters.AddWithValue("@Username", username);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Password updated successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Error updating password.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    reader.Close();
                    lblMessage.Text = "Incorrect old password.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    protected void btncancel_Click(object sender, EventArgs e)
        {
            txtoldpass.Text = "";
            txtnewpass.Text = "";
            txtconfpass.Text = "";
        }

        protected void btncanceluserupdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
    }
}