using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace InstaFashionShopping
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridview1();
        }
        private void BindGridview1()
        {
            SqlConnection con = new SqlConnection(Utility.ConnString);
            SqlCommand cmd = new SqlCommand(" SELECT user_id, full_name, username,password,email,phone,usertype FROM users", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
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
        

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex > GridView1.Rows.Count)
            {
                    int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
                    SqlConnection con = new SqlConnection(Utility.ConnString);
                    SqlCommand cmd = new SqlCommand("sp_DeleteUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    BindGridview1();
                
              
            }
        }
    }
}