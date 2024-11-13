using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace InstaFashionShopping
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sqlQuery = "SELECT full_name FROM users WHERE usertype = 'admin'";

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, con))
                    {
                        con.Open();

                        string adminName = (string)command.ExecuteScalar();

                        if (!string.IsNullOrEmpty(adminName))
                        {
                            Label1.Text = "Welcome! " + adminName;
                        }
                        else
                        {
                            Label1.Text = "Welcome! Admin";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Error loading admin details.";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Session.Abandon();

                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                Label1.Text = "An error occurred while logging out.";
            }
        }
    }
}
