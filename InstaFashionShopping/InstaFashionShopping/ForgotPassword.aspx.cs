using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Configuration;
using System.Data;

namespace InstaFashionShopping
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msg.Text = "";
            msg1.Text = "";
        }

        public void sendpassword(string password, string email)
        {
            try
            {
                // Setup the SMTP client with Gmail's SMTP server details
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",  // Gmail's SMTP host
                    Port = 587,               // Gmail's SMTP port
                    Credentials = new NetworkCredential("annapurnag2262@gmail.com", "tybl ivhy zaqv nbis"),  // App password here
                    EnableSsl = true          // Enable SSL for secure connection
                };

                // Create the email message
                MailMessage msg = new MailMessage
                {
                    Subject = "Forgotten Password",
                    Body = $"Dear {username.Text},\n\nYour Password is {password}\n\nThanks & Regards\n Insta-Fashion",
                    From = new MailAddress("Insta Fashion <annapurnag2262@gmail.com>")  // Sender's email address
                };
                msg.To.Add(email);  // Add the recipient's email

                // Send the email
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                // Log exception (could be stored in a file or database for production)
                throw new Exception("Error sending email. Please try again later.", ex);
            }
        }

        // Function to clear the textboxes and message labels
        public void clear()
        {
            username.Text = "";
            emailtxt.Text = "";
            msg.Text = "";
            msg1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string password;
            string connectionString = @"Data Source=ANNAPURNA\SQLAnna;Initial Catalog=Insta-FashionDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Using parameterized query to prevent SQL Injection
                string myquery = "SELECT * FROM users WHERE username = @username AND email = @email";
                SqlCommand cmd = new SqlCommand(myquery, con);
                cmd.Parameters.AddWithValue("@username", username.Text);  // Adding username parameter
                cmd.Parameters.AddWithValue("@email", emailtxt.Text);  // Adding email parameter

                // Open the connection and fetch data
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Decrypt password and send it to the email
                    password = Cryptography.Decrypt(Convert.ToString(ds.Tables[0].Rows[0]["password"]));
                    sendpassword(password, emailtxt.Text);  // Send email with the password

                    // Display success message
                    msg.Text = "Your Password Has Been Sent to Registered Email Address. Check Your Mail Inbox";
                    clear();  // Clear the fields after success
                }
                else
                {
                    // Display error message if username or email is not found
                    msg1.Text = "Your Username is Not Valid or Email Not Registered";
                }
                con.Close();
            }
        }
    }
}
