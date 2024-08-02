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
    public partial class EditCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridview();
        }

        protected void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("update Category set CatName=@Name where CatID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            cmd.Parameters.AddWithValue("@Name", txtUpdateCatName.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Update successfully')</script>");
            BindGridview();
            txtID.Text = string.Empty;
            txtUpdateCatName.Text = string.Empty;


        }

        private void BindGridview()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlDataAdapter da = new SqlDataAdapter("select CatID,CatName from Category", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void txtID_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("select CatName from Category where CatID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds, "dt");
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnUpdateCategory.Enabled = true;
                txtUpdateCatName.Text = ds.Tables[0].Rows[0]["CatName"].ToString();

            }
            else
            {
                btnUpdateCategory.Enabled = false;
                txtUpdateCatName.Text = string.Empty;
            }
            con.Close();
        }
    }
}