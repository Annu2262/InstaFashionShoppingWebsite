using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Drawing;

namespace InstaFashionShopping
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msg.Text = "";
            msg1.Text = "";
        }
        public void sendpassword(String password, String email)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("annapurnag2262@gmail.com", "gfczyeolckbodqis");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = "Forgotted Password";
            msg.Body = "Dear " + username.Text + ", Your Password is  " + password + "\n\n\nThanks & Regards\n Insta-Fashion";
            string toaddress = emailtxt.Text;
            msg.To.Add(toaddress);
            string fromaddress = "Insta Fashion <annapurnag2262@gmail.com>";
            msg.From = new MailAddress(fromaddress);
            try
            {
                smtp.Send(msg);


            }
            catch
            {
                throw;
            }
        }


        public void clear()
        {
            username.Text = "";
            emailtxt.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String password;

            using (
           SqlConnection con = new SqlConnection("Data Source=ANNAPURNA\\SQLEXPRESS;Initial Catalog=Insta-FashionDB;Integrated Security=True"))
            {
                String myquery = "select * from users where username='" + username.Text + "' and email='" + emailtxt.Text + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = myquery;
                cmd.Connection = con;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    password = Cryptography.Decrypt( Convert.ToString(ds.Tables[0].Rows[0]["password"]));
                    sendpassword(password, emailtxt.Text);

                    msg.Text ="Your Password Has Been Sent to Registered Email Address. Check Your Mail Inbox";
                    clear();
                   
                }
                else
                {
                    msg1.Text = "Your Username is Not Valid or Email Not Registered";

                }

                con.Close();

            }
        }
    }
}