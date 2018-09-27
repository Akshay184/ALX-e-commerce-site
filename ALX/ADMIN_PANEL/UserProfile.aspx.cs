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
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("select UserId,UserName,Email,ContactNumber,EmailVerified from userinformation ", con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                rptUserProfile.DataSource = ds;
                rptUserProfile.DataBind();
            }
   
        }
    }
}