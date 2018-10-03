using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ALX
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            Session["ID"] = 0;
            string csLogIn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(csLogIn))
                {

                    SqlCommand cmd = new SqlCommand("select UserId from tbluserinformation where UserName=@usernameaun and password=@passwordaun and EmailVerified=1", con);
                    cmd.Parameters.AddWithValue("@usernameaun", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@passwordaun", txtPassword.Text);


                    con.Open();
                    Session["ID"] = (int)cmd.ExecuteScalar();
                   
                        Response.Redirect("~/Welcome.aspx");
                    
                }
            }
            catch
            {
               
                Response.Write("Wrong INputs");
            }

        
        }
    }
}









