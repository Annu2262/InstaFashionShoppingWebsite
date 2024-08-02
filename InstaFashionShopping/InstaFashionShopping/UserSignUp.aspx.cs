using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InstaFashionShopping;

namespace InstaFashionShopping
{
    public partial class UserSignUp : System.Web.UI.Page
    {

        #region Variable declaration and Connection string 
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private readonly string connString = "Data Source=ANNAPURNA\\SQLEXPRESS;Initial Catalog=Insta-FashionDB;Integrated Security=True";
        private Boolean emailavailable = false;
        private Boolean usernameavailable = false;
        #endregion

        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This event heps to register Users and display sucessfull message 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Register(object sender, EventArgs e)
        {
            if (checkemail() == true)
            {
                if (lblemailerr != null)
                {
                    lblemailerr.Text = "Email Already Registered";
                }
                email_txt.Text = "";
                email_txt.Focus();
            }
            if (checkusername() == true)
            {
                lblunameerr.Text = "Username Already Taken";
                username_txt.Text = "";
                username_txt.Focus();

            }
            else
            {
                // Function to create User 
                CreateUser();
                Response.Write("<script> alert('Registration done successfully');</script>");
                Response.Redirect("Login.aspx");
            }
        }
        #endregion

        #region User defined Methods
        /// <summary>
        /// This Function helps us to create a user 
        /// </summary>
        public void CreateUser()
        {
            con = new SqlConnection(connString);
            con.Open();

            // Inserting a new row into the users table
            cmd = new SqlCommand("INSERT INTO users (full_name, email, phone, username, password, usertype) VALUES (@full_name, @email, @phone, @username, @password, 'User'); SELECT SCOPE_IDENTITY()", con);
            cmd.Parameters.AddWithValue("@full_name", name_txt.Text);
            cmd.Parameters.AddWithValue("@email", email_txt.Text);
            cmd.Parameters.AddWithValue("@phone", phone_txt.Text);
            cmd.Parameters.AddWithValue("@username", username_txt.Text);
            cmd.Parameters.AddWithValue("@password", Cryptography.Encrypt(Convert.ToString(pass_txt.Text)));

           

            int newUserId = Convert.ToInt32(cmd.ExecuteScalar());
            try
            {
                // Inserting a new row into the CartDetails table with the retrieved user_id value
                cmd = new SqlCommand("INSERT INTO CartDetails (uid) VALUES (@user_id)", con);
                cmd.Parameters.AddWithValue("@user_id", newUserId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            

            con.Close();
        }

        /// <summary>
        /// This function checks if the user provided email already exists or not 
        /// </summary>
        /// <returns></returns>

        private Boolean checkemail()
        {
            
            String myquery = "Select * from users where email='" + email_txt.Text + "'";
            con = new SqlConnection(connString);
            cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                emailavailable = true;

            }
            con.Close();

            return emailavailable;
        }
        private Boolean checkusername()
        {

            String myquery = "Select * from users where username='" + username_txt.Text + "'";
            con = new SqlConnection(connString);
            cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                usernameavailable = true;

            }
            con.Close();

            return usernameavailable;
        }

        #endregion
    }
}