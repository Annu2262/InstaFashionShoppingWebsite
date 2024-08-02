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
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductID();
                BindGender();
                BindCategory();
                BindBrand();
                BindSubCategory();
            }
        }
        private void BindProductID()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select PName,PID FROM Products", con);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlproductid.DataSource = dr;
                ddlproductid.DataTextField = "PName";
                ddlproductid.DataValueField = "PID";
                ddlproductid.DataBind();
                ddlproductid.Items.Insert(0, "-Select-");
                ddlproductid.Items[0].Selected = true;
            }
        }

        private void BindGender()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
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
                    ddlGender.Items[0].Selected = true;
                }
            }
        }

        private void BindCategory()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
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
                    ddlCategory.Items[0].Selected = true;
                }
            }
        }

        private void BindSubCategory()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from  SubCategory", con);
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
                    ddlSubCategory.Items[0].Selected = true;
                }
            }
        }

        private void BindBrand()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
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

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
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
                }
            }
        }

        protected void ddlproductid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productId = ddlproductid.SelectedValue.ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select p.*,b.Name,b.BrandID,c.CatName,c.CatID,g.GenderID,sc.SubCatName,sc.SubCatID,g.GenderName from Products p inner join Brand b on b.BrandId=p.PBrandId inner join Category c on c.CatID=p.PCategoryId inner join SubCategory sc on sc.SubCatID=p.PSubCatId inner join Gender g on g.GenderID=p.PGender where p.PID ='" + ddlproductid.SelectedValue.ToString() + "'", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtProductName.Text = reader["PName"].ToString();
                txtPrice.Text = reader["PPrice"].ToString();
                txtsellPrice.Text = reader["PSelPrice"].ToString();
                txtDescription.Text = reader["PDescription"].ToString();
                txtPDetail.Text = reader["PProductDetails"].ToString();
                txtMatCare.Text = reader["PMaterialCare"].ToString();

                string brandid = reader["BrandID"].ToString();
                ddlBrand.SelectedValue = brandid;
                // Set the selected value of the dropdown list, not the text property
                string category = reader["CatID"].ToString();
                ddlCategory.SelectedValue = category;
                string subcat = reader["SubCatID"].ToString();
                ddlSubCategory.SelectedValue = subcat;
                string gender = reader["GenderID"].ToString();
                ddlGender.SelectedValue = gender;
            }
        }

        public void clear()
        {
           ddlproductid.ClearSelection();
           ddlCategory.ClearSelection();
           ddlSubCategory.ClearSelection();
           ddlGender.ClearSelection();
           txtsellPrice.Text = "";
           txtPrice.Text = "";
           txtDescription.Text = "";
           txtPDetail.Text = "";
           txtMatCare.Text = "";
           txtProductName.Text = "";
           ddlBrand.ClearSelection();
           cbCOD.Checked=false;
           chFD.Checked=false;

        }
        public void updatedata()
        {
            try
            {
                string productId = ddlproductid.SelectedValue.ToString();
                string catid = ddlCategory.SelectedValue.ToString();
                string subcatid = ddlSubCategory.SelectedValue.ToString();
                string gender = ddlGender.SelectedValue.ToString();
                string sellprice = txtsellPrice.Text;
                string price = txtPrice.Text;
                string pdispription = txtDescription.Text;
                string pdetail = txtPDetail.Text;
                string matcare = txtMatCare.Text;
                string pname = txtProductName.Text;
                int b = cbCOD.Checked ? 1 : 0;
                int c = chFD.Checked ? 1 : 0;

                if (ddlCategory.SelectedValue.ToString() == "-Select-")
                {
                    catid = null;
                }

                if (ddlSubCategory.SelectedValue.ToString() == "-Select-")
                {
                    subcatid = null;
                }

                if (ddlGender.SelectedValue.ToString() == "-Select-")
                {
                    gender = null;
                }

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString))
                {
                    con.Open();
                    string query = "UPDATE Products SET PName=@pname, PPrice=@pprice, PSelPrice=@psellprice, PBrandID=@brandid, PCategoryID=@catid, PSubCatID=@subid, PGender=@gender, PDescription=@disp, PProductDetails=@pdetails, PMaterialCare=@pmaterialcare, FreeDelivery=@freedelievery, COD=@cod WHERE PID=@pid";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@pname", pname);
                        cmd.Parameters.AddWithValue("@pprice", price);
                        cmd.Parameters.AddWithValue("@psellprice", sellprice);
                        cmd.Parameters.AddWithValue("@brandid", ddlBrand.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@catid", catid);
                        cmd.Parameters.AddWithValue("@subid", subcatid);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@disp", pdispription);
                        cmd.Parameters.AddWithValue("@pdetails", pdetail);
                        cmd.Parameters.AddWithValue("@pmaterialcare", matcare);
                        cmd.Parameters.AddWithValue("@freedelievery", c);
                        cmd.Parameters.AddWithValue("@cod", b);
                        cmd.Parameters.AddWithValue("@pid", productId);

                        int i = cmd.ExecuteNonQuery();

                        if (i > 0)
                        {
                            Response.Write("<script>alert('Data has been updated successfully.')</script>");
                            clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred while updating the data. " + ex.Message + "')</script>");
            }

        }
        
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updatedata();
        }
    }
}