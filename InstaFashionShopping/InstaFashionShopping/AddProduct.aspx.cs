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
    public partial class AddProduct : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridview1();
            if (!IsPostBack)
            {
                //when page first time run then this code will execute
                BindBrand();
                BindCategory();
                BindGender();
                ddlSubCategory.Enabled = false;
                ddlGender.Enabled = false;

                BindGridview1();

            }
        }

        private void BindGender()
        {
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Gender with(nolock)", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlGender.DataSource = dt;
                    ddlGender.DataTextField = "GenderName";
                    ddlGender.DataValueField = "GenderID";
                    ddlGender.DataBind();
                    ddlGender.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }

        private void BindCategory()
        {
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Category", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlCategory.DataSource = dt;
                    ddlCategory.DataTextField = "CatName";
                    ddlCategory.DataValueField = "CatID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }

        private void BindBrand()
        {
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Brand", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlBrand.DataSource = dt;
                    ddlBrand.DataTextField = "Name";
                    ddlBrand.DataValueField = "BrandID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }
       



        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategory.Enabled = true;
            int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);

            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from SubCategory where MainCatID='" + ddlCategory.SelectedItem.Value + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlSubCategory.DataSource = dt;
                    ddlSubCategory.DataTextField = "SubCatName";
                    ddlSubCategory.DataValueField = "SubCatID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }

        protected string GetActiveImgClass(int ItemIndex)
        {
            if (ItemIndex == 0)
            {
                return "active";
            }
            else
            {
                return "";

            }
        }
        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubCategory.SelectedIndex != 0)
            {
                ddlGender.Enabled = true;
            }
            else
            {
                ddlGender.Enabled = false;
            }
        }

        private void BindGridview1()
        {
            SqlConnection con = new SqlConnection(Utility.ConnString);
            SqlCommand cmd = new SqlCommand("select  Products.PID,Products.PName,Products.PPrice,Products.PSelPrice,Brand.Name as Brand,Category.CatName,SubCategory.SubCatName,ProductImages.ImageData, Gender.GenderName as gender  from Products as products inner join Brand as Brand on Brand.BrandID=Products.PBrandID  inner join Category as Category on Category.CatID=Products.PCategoryID  inner join SubCategory as SubCategory on SubCategory.SubCatID=Products.PSubCatID   inner join Gender as Gender on Gender.GenderID =Products.PGender cross apply(select top 1 * from ProductImages where ProductImages.PID= Products.PID order by ProductImages.PID desc)ProductImages order by Products.PName", con);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@PPrice", txtPrice.Text);
                cmd.Parameters.AddWithValue("@PSelPrice", txtsellPrice.Text);
                cmd.Parameters.AddWithValue("@PBrandID", ddlBrand.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PSubCatID", ddlSubCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PGender", ddlGender.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PDescription", txtDescription.Text);
                cmd.Parameters.AddWithValue("@PProductDetails", txtPDetail.Text);
                cmd.Parameters.AddWithValue("@PMaterialCare", txtMatCare.Text);
                if (chFD.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
                }
                
                if (cbCOD.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@COD", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@COD", 0.ToString());
                }
                if (con.State == ConnectionState.Closed) { con.Open(); }
                Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());


               
                //Image Upload
                if (fuImg01.HasFile)
                {
                    byte[] imageBytes = new byte[fuImg01.PostedFile.InputStream.Length];
                    fuImg01.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length);

                    // insert the image into the database
                    SqlCommand cmd3 = new SqlCommand("insert into ProductImages(PID,Name,ImageData) values(@PID,@Name,@ImageData)", con);
                    cmd3.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                    cmd3.Parameters.AddWithValue("@Name", fuImg01.FileName);
                    cmd3.Parameters.Add("@ImageData", SqlDbType.Image, imageBytes.Length).Value = imageBytes;
                    cmd3.ExecuteNonQuery();
                }
                if (fuImg02.HasFile)
                {
                    byte[] imageBytes = new byte[fuImg02.PostedFile.InputStream.Length];
                    fuImg02.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length);

                    // insert the image into the database
                    SqlCommand cmd3 = new SqlCommand("insert into ProductImages(PID,Name,ImageData) values(@PID,@Name,@ImageData)", con);
                    cmd3.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                    cmd3.Parameters.AddWithValue("@Name", fuImg01.FileName);
                    cmd3.Parameters.Add("@ImageData", SqlDbType.Image, imageBytes.Length).Value = imageBytes;
                    cmd3.ExecuteNonQuery();
                }
                if (fuImg03.HasFile)
                {
                    byte[] imageBytes = new byte[fuImg03.PostedFile.InputStream.Length];
                    fuImg03.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length);

                    // insert the image into the database
                    SqlCommand cmd3 = new SqlCommand("insert into ProductImages(PID,Name,ImageData) values(@PID,@Name,@ImageData)", con);
                    cmd3.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                    cmd3.Parameters.AddWithValue("@Name", fuImg01.FileName);
                    cmd3.Parameters.Add("@ImageData", SqlDbType.Image, imageBytes.Length).Value = imageBytes;
                    cmd3.ExecuteNonQuery();
                }
 
            }
            Response.Write("<script> alert('Product has been Added Successfully');  </script>");
            BindGridview1();
            Response.Redirect("AddProduct.aspx");
        }   
    }
}
