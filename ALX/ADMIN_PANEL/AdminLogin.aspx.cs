using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ALX.ADMIN_PANEL
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["AdminId"] = "";
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("Select AdminId from tblAdminLogin where Username=@UserName and Password=@Password", con);
                    cmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    con.Open();
                    Session["AdminId"] = (int)cmd.ExecuteScalar();
                    lblLoginText.Text = "Login Successful";
                    Response.Redirect("~/ADMIN_PANEL/adminHome.aspx");
                }
            }
            catch
            {
                lblLoginText.Text = "Wrong Credentials";
            }
        }
    }
}