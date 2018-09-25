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
using System.Net.Mail;

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

                    Session["UserName"] = TextBox1.Text;

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
                        ConfirmationEmail();
                        Response.Write("A mail has been send to your email address.Please verify it to continue ");
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

        private void ConfirmationEmail()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string ActivationCode = "";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select ActivationCode from UserInformation where UserName=@UserName",con);
                cmd.Parameters.AddWithValue("@UserName", TextBox1.Text);
                con.Open();
                 ActivationCode = cmd.ExecuteScalar().ToString();

            }

            using (MailMessage mailmessage = new MailMessage("ucancallmeakshay@gmail.com", TextBox3.Text))
            {
                String a = Request.Url.AbsoluteUri.Replace("SignUp", "EmailVerification.aspx?ActivationCode=" + ActivationCode);
                mailmessage.Subject = "Email Verication For Your ALX Account";
                string body = "Hello " + TextBox1.Text;
                body += "<br />  Please Follow the bellow link to verify your account";
                body += "<br /> <a href='" + Request.Url.AbsoluteUri.Replace("SignUp", "EmailVerification.aspx?ActivationCode=" + ActivationCode) + "' >Click here to activate your account</a>";
                body += "<br/ >Thanks";
                mailmessage.Body = body;
                mailmessage.IsBodyHtml = true;
                SmtpClient smptclient = new SmtpClient("smtp.gmail.com", 587);
                smptclient.EnableSsl=true;
                smptclient.Credentials = new System.Net.NetworkCredential("ucancallmeakshay@gmail.com", "akshay123");
                smptclient.Send(mailmessage);
            }

        }

        
    }
}


