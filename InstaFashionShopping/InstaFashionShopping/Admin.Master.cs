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
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
            string sqlQuery = "SELECT full_name FROM users WHERE usertype = 'admin'";
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    con.Open();
                    
                    string adminName = (string)command.ExecuteScalar();

                    Label1.Text = "Welcome! " + adminName;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            // Redirect to the login page
            Response.Redirect("Default.aspx");
        }
    }
}