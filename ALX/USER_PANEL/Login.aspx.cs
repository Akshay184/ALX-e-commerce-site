using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace ALX.USER_PANEL
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string message =  Request.QueryString["EmailVerification"].ToString();
            //lblEmail.Text = message;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
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
                    Session["UserId"] = (int)cmd.ExecuteScalar();
                }
                    Response.Redirect("~/USER_PANEL/ALXHome.aspx");

                
            }
            catch
            {

                //Response.Redirect("~/USER_PANEL/Signup.aspx");
            }


        }

        protected void Books(object sender, EventArgs e)
        {
            Response.Redirect("~/USER_PANEL/Products.aspx?Category=Books");
        }

        protected void Clothes(object sender, EventArgs e)
        {
            Response.Redirect("~/USER_PANEL/Products.aspx?Category=Clothes");
        }

        protected void Electronics(object sender, EventArgs e)
        {
            Response.Redirect("~/USER_PANEL/Products.aspx?Category=Electronics");
        }

        protected void Furniture(object sender, EventArgs e)
        {
            Response.Redirect("~/USER_PANEL/Products.aspx?Category=Furniture");
        }

        protected void Vehicles(object sender, EventArgs e)
        {
            Response.Redirect("~/USER_PANEL/Products.aspx?Category=Vehicles");
        }
    }
}