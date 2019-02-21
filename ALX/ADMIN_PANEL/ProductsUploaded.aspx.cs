using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ALX.ADMIN_PANEL
{
    public partial class ProductsUploaded : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
                if(Session["UserId"] == null)
                {
                Response.Redirect("~/ADMIN_PANEL/AdminLogin.aspx");

            }
                else
                {
                    
                if (!IsPostBack)
                {
                    rptUploadedProducts.DataSource = GetData();
                    rptUploadedProducts.DataBind();
                }


            }
            
        }
        protected void Edit(object sender, CommandEventArgs e)
        {
            string ID = e.CommandArgument.ToString();
            Response.Redirect("~/ADMIN_PANEL/ProductsUpdate?ProductId=" + ID);
        }

        protected DataSet GetData()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tblProducts ", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        protected void Delete(object sender, CommandEventArgs e)
        {
            string CurrentProductId = e.CommandArgument.ToString();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("delete from tblProducts where ProductId=@CurrentId", con);
                cmd.Parameters.AddWithValue("@CurrentId", CurrentProductId);
                con.Open();
                cmd.ExecuteNonQuery();
                rptUploadedProducts.DataSource = GetData();
                rptUploadedProducts.DataBind();
            }
        }
    }
}