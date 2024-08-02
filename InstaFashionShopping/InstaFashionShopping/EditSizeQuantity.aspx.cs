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
    public partial class EditSizeQuantity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductID();
                BindSize();
                BindQuantity();
            }
        }
        protected void BindSize()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SizeName,SizeID FROM Size", con);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlsize.DataSource = dr;
                ddlsize.DataTextField = "SizeName";
                ddlsize.DataValueField = "SizeID";

                ddlsize.DataBind();
                ddlsize.Items.Insert(0, "-Select-");
                ddlsize.Items[0].Selected = true;
                ddlsize.Items[0].Attributes["Disabled"] = "Disabled";
            }
        }
        private void BindProductID()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PName,PID FROM Products", con);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlproductid.DataSource = dr;
                ddlproductid.DataTextField = "PName";
                ddlproductid.DataValueField = "PID";
                ddlproductid.DataBind();
                ddlproductid.Items.Insert(0, "-Select-");
                ddlproductid.Items[0].Selected = true;
                ddlproductid.Items[0].Attributes["Disabled"] = "Disabled";
            }
        }



        protected void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            // Retrieve the selected size, product ID, and new quantity from the form
            int sizeID = Convert.ToInt32(ddlsize.SelectedValue);
            int productID = Convert.ToInt32(ddlproductid.SelectedValue);
            int newQuantity = Convert.ToInt32(txtquantity.Text);

            // Check if the quantity for the selected size and product ID already exists in the database
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmdCheckQuantity = new SqlCommand("SELECT Quantity FROM ProductSizeQuantity WHERE SizeID = @SizeID AND PID = @PID", con);
                cmdCheckQuantity.Parameters.AddWithValue("@SizeID", sizeID);
                cmdCheckQuantity.Parameters.AddWithValue("@PID", productID);
                int previousQuantity = Convert.ToInt32(cmdCheckQuantity.ExecuteScalar());

                // If the quantity already exists, add the new quantity to the previous quantity and update the database
                if (previousQuantity > 0)
                {
                    int updatedQuantity = previousQuantity + newQuantity;
                    SqlCommand cmdUpdateQuantity = new SqlCommand("UPDATE ProductSizeQuantity SET Quantity = @Quantity WHERE SizeID = @SizeID AND PID = @PID", con);
                    cmdUpdateQuantity.Parameters.AddWithValue("@Quantity", updatedQuantity);
                    cmdUpdateQuantity.Parameters.AddWithValue("@SizeID", sizeID);
                    cmdUpdateQuantity.Parameters.AddWithValue("@PID", productID);
                    cmdUpdateQuantity.ExecuteNonQuery();
                }
                // If the quantity does not exist, insert a new record in the database
                else
                {
                    SqlCommand cmdInsertQuantity = new SqlCommand("INSERT INTO ProductSizeQuantity (SizeID, PID, Quantity) VALUES (@SizeID, @PID, @Quantity)", con);
                    cmdInsertQuantity.Parameters.AddWithValue("@SizeID", sizeID);
                    cmdInsertQuantity.Parameters.AddWithValue("@PID", productID);
                    cmdInsertQuantity.Parameters.AddWithValue("@Quantity", newQuantity);
                    cmdInsertQuantity.ExecuteNonQuery();
                }
            }

            // Display a success message to the user
            Response.Write("<script>alert('Quantity updated successfully.');</script>");
            Response.Redirect(Request.RawUrl);
            txtquantity.Text = "";
            ddlproductid.ClearSelection();
            ddlsize.ClearSelection();
        }
        private void BindQuantity()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select psq.*,p.PName,s.SizeName from ProductSizeQuantity psq inner join Products p on p.PID=psq.PID inner join Size s on s.SizeID=psq.SizeID", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrSizeQuantity.DataSource = dt;
                        rptrSizeQuantity.DataBind();
                    }
                }
            }
        }
    }
    }
