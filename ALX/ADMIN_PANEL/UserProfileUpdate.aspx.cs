using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ALX.ADMIN_PANEL
{
    public partial class Editing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
                if (Session["UserId"] != null)
                {
                if (!IsPostBack)
                {
                    DataSet ds = GetData();
                    txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtContactNumber.Text = ds.Tables[0].Rows[0]["ContactNumber"].ToString();
                }
                   
                }
                else
                {
                    Response.Redirect("~/ADMIN_PANEL/AdmiLogin.aspx");
                }
            
        }

        protected void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private DataSet GetData()
        {
            string ID =  Request.QueryString["UserId"];
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from tblUserInformation where UserId="+ID+"",con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                
                return ds;
                
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string ID = Request.QueryString["UserId"];
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("update tblUserInformation set UserName=@UserName,Email=@Email,ContactNumber=@ContactNumber where UserId="+ID+"", con);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect("~/ADMIN_PANEL/UserProfile.aspx");
                Response.Write("UPDATE SUCCESSFULLY");
            }
        }
    }
}