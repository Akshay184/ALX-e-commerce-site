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

                    SqlCommand cmd = new SqlCommand("select UserId from userinformation where UserName=@usernameaun and password=@passwordaun", con);
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










//SqlCommand cmd = new SqlCommand("login", con);
//cmd.CommandType = CommandType.StoredProcedure;

//                SqlParameter UserName = new SqlParameter("@UserNameAun", txtUserName.Text);
//SqlParameter Password = new SqlParameter("@PasswordAun", txtPassword.Text);

//cmd.Parameters.Add(UserName);
//                cmd.Parameters.Add(Password);
//                con.Open();

//                int Authentication = (int)cmd.ExecuteScalar();
//                if (Authentication == 1)
//                {
//                    Response.Redirect("~/Welcome.aspx");
//                }
//                else
//                {
//                    Response.Write("Invalid UserName");
//                }