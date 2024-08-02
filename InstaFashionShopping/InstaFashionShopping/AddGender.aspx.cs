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
    public partial class AddGender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGenderReapter();
        }
        private void BindGenderReapter()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Gender", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrGender.DataSource = dt;
                        rptrGender.DataBind();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
            {
                con.Open();
                string sql = "INSERT INTO Gender(GenderName) VALUES(@genderName)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@genderName", txtGender.Text);
                cmd.ExecuteNonQuery();
            

            Response.Write("<script> alert('Gender Added Successfully ');  </script>");
                txtGender.Text = string.Empty;

                con.Close();
                txtGender.Focus();

            }
        }
    }
}