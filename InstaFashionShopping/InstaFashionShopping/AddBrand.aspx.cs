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
    public partial class AddBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandRepeater();
            }
        }
        private void BindBrandRepeater()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Brand", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrBrands.DataSource = dt;
                        rptrBrands.DataBind();
                    }
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (txtBrand.Text != null && txtBrand.Text != "" && txtBrand.Text != string.Empty)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Brand(Name) Values('" + txtBrand.Text + "')", con);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script> alert('Brand Added Successfully ');  </script>");
                    txtBrand.Text = string.Empty;

                    con.Close();
                    BindBrandRepeater();
                    txtBrand.Focus();
                }
            }
        }
    }
}