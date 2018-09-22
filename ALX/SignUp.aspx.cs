using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;

namespace ALX
{
    public partial class Login : System.Web.UI.Page
    {
        
        //string n = String.Format("{0}", Request.Form["customerName"]);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox2.Text, "SHA1");
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SignUp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter UserName = new SqlParameter("@UserName", TextBox1.Text);
                    SqlParameter Password = new SqlParameter("@Password", TextBox2.Text);
                    SqlParameter Email = new SqlParameter("@Email", TextBox3.Text);
                    SqlParameter ContactNumber = new SqlParameter("@ContactNumber", TextBox4.Text);

                    cmd.Parameters.Add(UserName);
                    cmd.Parameters.Add(Password);
                    cmd.Parameters.Add(Email);
                    cmd.Parameters.Add(ContactNumber);

                    con.Open();
                    int ReturnCount = (int)cmd.ExecuteScalar();
                    if (ReturnCount == 1)
                    {
                        Response.Write("User/Email Already exist");
                    }
                    else
                    {
                        Response.Redirect("~/LogIn.aspx");
                    }
                }

            }
          
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LogIn.aspx");
        }

        public void ConfirmationEmail(int ID)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string ActivationCode = Guid.NewGuid().ToString();
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Insert into tblEmailVerification values (@ID, @code)");
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@code", ActivationCode);

            }
        }
    }
}


