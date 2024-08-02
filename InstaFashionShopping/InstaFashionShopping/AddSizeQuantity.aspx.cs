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
    public partial class AddSizeQuantity : System.Web.UI.Page
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

        protected void ddlproductid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(ddlproductid.SelectedValue);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT PName FROM Products WHERE PID = @productId", con);
            cmd.Parameters.AddWithValue("@productId", productId);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            con.Close();
        }
        protected void btnAddSizeQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                string pid = ddlproductid.SelectedValue.ToString();
                string SizeId = ddlsize.SelectedValue.ToString();
                int quantity = Convert.ToInt32(txtquantity.Text);
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO ProductSizeQuantity (PID, SizeId, quantity) VALUES (@pid, @SizeID, @quantity)", con);
                    cmd.Parameters.AddWithValue("@pid", ddlproductid.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SizeID", ddlsize.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@quantity", txtquantity.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {

                        Response.Write("<script> alert('Size and Quantity Added Successfully ');</script>");
                        txtquantity.Text = "";
                        ddlproductid.ClearSelection();
                        ddlsize.ClearSelection();
                    }
                    else
                    {
                        Response.Write("<script> alert('Failed to add Size and Quantity');</script>");
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    string message = "Failed to Add Size and Quantity. The quantity for this size has already been added to the product. Please edit the existing entry to update the quantity.";
                   
                    Response.Write($"<script>alert('{message}'); window.location.href = '{Request.RawUrl}';</script>");
                }
            }
        }
    }
}