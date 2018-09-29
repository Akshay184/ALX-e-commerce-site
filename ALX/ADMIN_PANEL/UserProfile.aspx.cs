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
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Session["AdminId"]) != 1)
                {
                    Response.Redirect("~/ADMIN_PANEL/AdminLogin.aspx");
                }
                else
                {
                    rptUserProfile.DataSource = GetData();
                    rptUserProfile.DataBind();
                }
            }
   
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
           
          
        }

        protected void Delete(object sender,CommandEventArgs e)
        {
            string CurrentUserId = e.CommandArgument.ToString();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "Delete from userInformation where userId=@CurrentId;";
                query += "Delete from tblProducts where USerId=@CurrentId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CurrentId", CurrentUserId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            rptUserProfile.DataSource = GetData();
            rptUserProfile.DataBind();
        }

        private DataSet GetData()
        {

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("select UserId,UserName,Email,ContactNumber,EmailVerified from userinformation ", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
               
            }
        }
        
    }
}