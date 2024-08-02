using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace InstaFashionShopping
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string GetUserEmail(int userId)
        {
            string email = "";
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                SqlCommand cmd = new SqlCommand("SELECT email FROM Users WHERE username = @username",con);
                {
                    cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        email = result.ToString();
                    }
                }
            }
            return email;
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(GetUserEmail(0));
            mail.To.Add(new MailAddress("annapurnag2262@gmail.com"));
            mail.Subject = txtsubject.Text;
            mail.Body = "From: " + txtfirstname.Text + "<br/>" + txtmess.Text;
            mail.IsBodyHtml = true;

            // Set up the SMTP client

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("annapurnag2262@gmail.com", "gfczyeolckbodqis");
            smtp.EnableSsl = true;

            // Send the email
            try
            {
                smtp.Send(mail);
                Response.Write("<script>alert('Your message has been sent. Thank you for contacting us.')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred while sending the email. Please try again later.')</script>");

            }
        }


    }
}
