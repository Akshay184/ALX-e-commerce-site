using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ALX.ADMIN_PANEL
{
    public partial class ProductsUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] != null)
            {
                if (!IsPostBack)
                {
                    DataSet ds = GetData();
                    txtProductName.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();
                    txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                    txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    txtCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                }

            }
            else
            {
                Response.Redirect("~/ADMIN_PANEL/AdminLogin.aspx");
            }
            
        }

        private DataSet GetData()
        {
            string ID = Request.QueryString["ProductId"];
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from tblProducts where ProductId=" + ID + "", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                
                return ds;

            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string ID = Request.QueryString["ProductId"];
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Update tblProducts set ProductName=@ProductName,Price=@Price,Description=@Description,Category=@Category where ProductId="+ID+"", con);
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Category",txtCategory.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect("~/ADMIN_PANEL/ProductsUploaded.aspx");
                
            }
        }
    }
}