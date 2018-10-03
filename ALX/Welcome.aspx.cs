using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ALX
{
    public partial class Welcome : System.Web.UI.Page
    {
        private int PageSize = 3;
        private string CATEGORY;
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Convert.ToInt32(Session["ID"])==0)
            {
                Response.Redirect("~/LogIn.aspx");
            }
            Response.Write(Session["Id"]);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["ID"]= 0;
            Response.Redirect("~/LogIn.aspx");
        }

        protected void btnFurniture_Click(object sender, EventArgs e)
        {
            DataSet ds = GetData("Furniture");
            CATEGORY = "Furniture";
            
            rptProduct.DataSource = ds;
           // if (!IsPostBack)
           // {
                
            //}
            rptProduct.DataBind();
            this.GetCustomersPageWise(1);//,CATEGORY);
        }

        private DataSet GetData(string category)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select ProductName,Price,Description,images from tblProducts where CATEGORY='"+category+"'", con);
                
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile.aspx");
        }

        protected void btnBooks_Click(object sender, EventArgs e)
        {
            DataSet ds = GetData("Books");
            CATEGORY = "Books";
            rptProduct.DataSource = ds;
            rptProduct.DataBind();
            this.GetCustomersPageWise(1);//,CATEGORY);

        }

        protected void btnElectronics_Click(object sender, EventArgs e)
        {
            DataSet ds = GetData("Electronics");
            CATEGORY = "Electronics";
            rptProduct.DataSource = ds;
          //  if (!IsPostBack)
           // {
                
            //}
            rptProduct.DataBind();
            this.GetCustomersPageWise(1);//,CATEGORY);
        }
        protected void btnVehicles_Click(object sender, EventArgs e)
        {
            DataSet ds = GetData("Vehicles");
            CATEGORY = "Vehicles";
            rptProduct.DataSource = ds;
            //  if (!IsPostBack)
            // {

            //}
            rptProduct.DataBind();
            this.GetCustomersPageWise(1);//,CATEGORY);
        }
        protected void btnClothing_Click(object sender, EventArgs e)
        {
            DataSet ds = GetData("Clothing");
            CATEGORY = "Clothing";
            rptProduct.DataSource = ds;
            //  if (!IsPostBack)
            // {

            //}
            rptProduct.DataBind();
            this.GetCustomersPageWise(1); //,CATEGORY);
        }

        private void GetCustomersPageWise(int pageIndex)//,string CATEGORY)     //this functions calls the stored procedures from database
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("GetCustomersPageWise", con))
                {   
                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    

                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", PageSize);
                    
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                    cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                  //  SqlCommand cmd1 = new SqlCommand("SELECT Images,Price,CATEGORY,ProductName,Description FROM tblProducts where CATEGORY=@CATEGORY", con);
                    if (CATEGORY == "Furniture" || CATEGORY == "Books" || CATEGORY == "Vehicles" || CATEGORY == "Electronics" || CATEGORY == "Clothing")
                    {
                      //  cmd1.ExecuteNonQuery();
                        cmd.Parameters.AddWithValue("@CATEGORY", CATEGORY);
                    }
                    con.Open();

                    IDataReader ds = cmd.ExecuteReader();
                    
                    rptProduct.DataSource = ds;
                    rptProduct.DataBind();
                    ds.Close();
                    con.Close();
                    int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    this.PopulatePager(recordCount, pageIndex);
                }
            }
        }
       /* private void GetCustomersPageWiseBooks(int pageIndex,CATEGORY)     //this functions calls the stored procedures from database
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("GetCustomersPageWise", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    CATEGORY = "Books";
                    cmd.Parameters.AddWithValue("@CATEGORY", CATEGORY);
                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", PageSize);

                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                    cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                    con.Open();

                    IDataReader ds = cmd.ExecuteReader();

                    rptProduct.DataSource = ds;
                    rptProduct.DataBind();
                    ds.Close();
                    con.Close();
                    int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    this.PopulatePager(recordCount, pageIndex);
                }
            }
        }
        private void GetCustomersPageWiseVehicles(int pageIndex)     //this functions calls the stored procedures from database
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("GetCustomersPageWise", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    CATEGORY = "Vehicles";
                    cmd.Parameters.AddWithValue("@CATEGORY", CATEGORY);
                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", PageSize);

                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                    cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                    con.Open();

                    IDataReader ds = cmd.ExecuteReader();

                    rptProduct.DataSource = ds;
                    rptProduct.DataBind();
                    ds.Close();
                    con.Close();
                    int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    this.PopulatePager(recordCount, pageIndex);
                }
            }
        }
        private void GetCustomersPageWiseElectronics(int pageIndex)     //this functions calls the stored procedures from database
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("GetCustomersPageWise", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    CATEGORY = "Electronics";
                    cmd.Parameters.AddWithValue("@CATEGORY", CATEGORY);
                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", PageSize);

                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                    cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                    con.Open();

                    IDataReader ds = cmd.ExecuteReader();

                    rptProduct.DataSource = ds;
                    rptProduct.DataBind();
                    ds.Close();
                    con.Close();
                    int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    this.PopulatePager(recordCount, pageIndex);
                }
            }
        }
        private void GetCustomersPageWiseClothing(int pageIndex)     //this functions calls the stored procedures from database
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("GetCustomersPageWise", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    CATEGORY = "Clothing";
                    cmd.Parameters.AddWithValue("@CATEGORY", CATEGORY);
                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", PageSize);

                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                    cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                    con.Open();

                    IDataReader ds = cmd.ExecuteReader();

                    rptProduct.DataSource = ds;
                    rptProduct.DataBind();
                    ds.Close();
                    con.Close();
                    int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    this.PopulatePager(recordCount, pageIndex);
                }
            }
        }*/



        private void PopulatePager(int recordCount, int currentPage) //this function controls and call the page number been clicked
        {
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            List<ListItem> pages = new List<ListItem>();
            if (pageCount > 0)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
            }
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.GetCustomersPageWise(pageIndex);
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)    //...Search Button function
        {
           
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);


               
                if(txtSearch.Text != "")
            {   if (DropDownListFilters.SelectedValue =="0")
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from tblProducts where ProductName like '%' + @ProductName + '%'", con);

                    da.SelectCommand.Parameters.AddWithValue("ProductName", txtSearch.Text);
                    // da.SelectCommand.Parameters.AddWithValue("filter", DropDownListFilters.SelectedItem);
                    //if(DropDownListFilters.SelectedItem == "High-t)
                    da.Fill(ds);
                    rptProduct.DataSource = ds;
                    rptProduct.DataBind();
                }
               else if(DropDownListFilters.SelectedValue == "1")
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from tblProducts where ProductName like '%' + @ProductName + '%' Order BY price DESC", con);

                    da.SelectCommand.Parameters.AddWithValue("ProductName", txtSearch.Text);
                    // da.SelectCommand.Parameters.AddWithValue("filter", DropDownListFilters.SelectedItem);
                    //if(DropDownListFilters.SelectedItem == "High-t)
                    da.Fill(ds);
                    rptProduct.DataSource = ds;
                    rptProduct.DataBind();
                }
            else
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from tblProducts where ProductName like '%' + @ProductName + '%' Order BY price ASC", con);

                    da.SelectCommand.Parameters.AddWithValue("ProductName", txtSearch.Text);
                    // da.SelectCommand.Parameters.AddWithValue("filter", DropDownListFilters.SelectedItem);
                    //if(DropDownListFilters.SelectedItem == "High-t)
                    da.Fill(ds);
                    rptProduct.DataSource = ds;
                    rptProduct.DataBind();
                }
            }
            else
            {
                rptProduct.DataBind();
            }
               
            
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}