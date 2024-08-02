using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Threading;

namespace InstaFashionShopping
{
    public partial class Dresses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProductRepeater();
            r1.Checked = false;
            r2.Checked = false;
            r3.Checked = false;
            r4.Checked = false;
            r5.Checked = false;
            r6.Checked = false;
        }

        protected override void InitializeCulture()
        {
            CultureInfo ci = new CultureInfo("en-IN");
            ci.NumberFormat.CurrencySymbol = "₹";
            Thread.CurrentThread.CurrentCulture = ci;

            base.InitializeCulture();
        }

        private void BindProductRepeater()
        {
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("procBindDresses", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrProducts.DataSource = dt;
                        rptrProducts.DataBind();
                        if (dt.Rows.Count <= 0)
                        {
                            Label1.Text = "Sorry! Currently no products in this category.";
                        }
                        else
                        {
                            Label1.Text = "Showing All Products";
                        }
                    }
                }
            }
        }

        protected void txtFilterGrid1Record_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterGrid1Record.Text != string.Empty)
            {
                string searchTerm = txtFilterGrid1Record.Text;

                using (SqlConnection con = new SqlConnection(Utility.ConnString))
                {
                    string qr = "SELECT A.*, B.*, C.Name, A.PPrice - A.PSelPrice AS DiscAmount, B.Name AS ImageName, C.Name AS BrandName, D.CatName AS CategoryName FROM Products A INNER JOIN Brand C ON C.BrandID = A.PBrandID INNER JOIN Category D ON D.CatID= A.PCategoryId CROSS APPLY (SELECT TOP 1 * FROM ProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE CatName='Dress' And(A.PName LIKE '%' + @searchTerm + '%' OR C.Name LIKE @searchTerm + '%') ORDER BY A.PID DESC";
                    SqlDataAdapter da = new SqlDataAdapter(qr, con);
                    da.SelectCommand.Parameters.AddWithValue("@searchTerm", searchTerm);

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rptrProducts.DataSource = ds.Tables[0];
                        rptrProducts.DataBind();
                        Label1.Visible = false;
                    }
                    else
                    {
                        rptrProducts.DataSource = null;
                        rptrProducts.DataBind();
                        Label1.Text = "No products found.";
                        Label1.Visible = true;
                    }
                }
            }
            else
            {
                BindProductRepeater();
                Label1.Visible = false;
            }
        }



        protected void r1_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                con.Open();
                string query = "select A.*,B.*,C.Name ,A.PPrice-A.PSelPrice as DiscAmount,B.Name as ImageName, C.Name as BrandName,D.CatName as CategoryName from Products A inner join Brand C on C.BrandID = A.PBrandID inner join Category D on D.CatID = A.PCategoryID cross apply( select top 1 * from ProductImages B where B.PID = A.PID order by B.PID desc)B where CatName='Dress'AND (PSelPrice between 0 and 500) order by A.PID desc";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dt = cmd.ExecuteReader();

                rptrProducts.DataSource = dt;
                rptrProducts.DataBind();
                if (dt.Read())
                {
                    Label1.Text = "Sorry! Currently no products in this category.";
                }
                else
                {
                    Label1.Text = "Showing Products Between ₹0 to ₹500 ";
                }

                con.Close();
            }
        }

        protected void r2_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                con.Open();
                string query = "select A.*,B.*,C.Name ,A.PPrice-A.PSelPrice as DiscAmount,B.Name as ImageName, C.Name as BrandName,D.CatName as CategoryName from Products A inner join Brand C on C.BrandID = A.PBrandID inner join Category D on D.CatID = A.PCategoryID cross apply( select top 1 * from ProductImages B where B.PID = A.PID order by B.PID desc)B where CatName='Dress'AND ( PSelPrice between 500 and 1000) order by A.PID desc";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dt = cmd.ExecuteReader();

                rptrProducts.DataSource = dt;
                rptrProducts.DataBind();
                if (dt.Read())
                {
                    Label1.Text = "Sorry! Currently no products in this category.";
                }
                else
                {
                    Label1.Text = "Showing Products Between ₹1000 to ₹1500 ";
                }
                con.Close();

            }
        }

        protected void r3_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                con.Open();
                string query = "select A.*,B.*,C.Name ,A.PPrice-A.PSelPrice as DiscAmount,B.Name as ImageName, C.Name as BrandName,D.CatName as CategoryName from Products A inner join Brand C on C.BrandID = A.PBrandID inner join Category D on D.CatID = A.PCategoryID cross apply( select top 1 * from ProductImages B where B.PID = A.PID order by B.PID desc)B where CatName='Dress'AND ( PSelPrice between 1000 and 1500)order by A.PID desc";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dt = cmd.ExecuteReader();

                rptrProducts.DataSource = dt;
                rptrProducts.DataBind();
                if (dt.Read())
                {
                    Label1.Text = "Sorry! Currently no products in this category.";
                }
                else
                {
                    Label1.Text = "Showing Products Between ₹1500 to ₹2000 ";
                }

                con.Close();
            }
        }

        protected void r4_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                con.Open();
                string query = "select A.*,B.*,C.Name ,A.PPrice-A.PSelPrice as DiscAmount,B.Name as ImageName, C.Name as BrandName,D.CatName as CategoryName from Products A inner join Brand C on C.BrandID = A.PBrandID inner join Category D on D.CatID = A.PCategoryID cross apply( select top 1 * from ProductImages B where B.PID = A.PID order by B.PID desc)B where CatName='Dress'AND ( PSelPrice between 1500 and 2000 )order by A.PID desc";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dt = cmd.ExecuteReader();

                rptrProducts.DataSource = dt;
                rptrProducts.DataBind();
                if (dt.Read())
                {
                    Label1.Text = "Sorry! Currently no products in this category.";
                }
                else
                {
                    Label1.Text = "Showing Products Between ₹2000 to ₹2500 ";
                }

                con.Close();
            }
        }

        protected void r5_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                con.Open();
                string query = "select A.*,B.*,C.Name ,A.PPrice-A.PSelPrice as DiscAmount,B.Name as ImageName, C.Name as BrandName,D.CatName as CategoryName from Products A inner join Brand C on C.BrandID = A.PBrandID inner join Category D on D.CatID = A.PCategoryID cross apply( select top 1 * from ProductImages B where B.PID = A.PID order by B.PID desc)B where CatName='Dress'AND (PSelPrice between 2000 and 2500) order by A.PID desc";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dt = cmd.ExecuteReader();

                rptrProducts.DataSource = dt;
                rptrProducts.DataBind();
                if (dt.Read())
                {
                    Label1.Text = "Sorry! Currently no products in this category.";
                }
                else
                {
                    Label1.Text = "Showing Products Greater Than ₹2500 ";
                }

                con.Close();
            }
        }

        protected void r6_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Utility.ConnString))
            {
                con.Open();
                string query = "select A.*,B.*,C.Name ,A.PPrice-A.PSelPrice as DiscAmount,B.Name as ImageName, C.Name as BrandName,D.CatName as CategoryName from Products A inner join Brand C on C.BrandID = A.PBrandID inner join Category D on D.CatID = A.PCategoryID cross apply( select top 1 * from ProductImages B where B.PID = A.PID order by B.PID desc)B where CatName='Dress'AND (PSelPrice between 2500 and above) order by A.PID desc";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dt = cmd.ExecuteReader();

                rptrProducts.DataSource = dt;
                rptrProducts.DataBind();
                if (dt.Read())
                {
                    Label1.Text = "Sorry! Currently no products in this category.";
                }
                else
                {
                    Label1.Text = "Showing All Products";
                }
                con.Close();

            }
        }
    }
}