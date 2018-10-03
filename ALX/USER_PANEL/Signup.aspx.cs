using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Web.Security;
using System.Data;

namespace ALX.USER_PANEL
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //if (Page.IsValid)
            //{
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SignUp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter UserName = new SqlParameter("@UserName", txtUserName.Text);
                    SqlParameter Password = new SqlParameter("@Password", hashedPassword);
                    SqlParameter Email = new SqlParameter("@Email", txtEmail.Text);
                    SqlParameter ContactNumber = new SqlParameter("@ContactNumber", txtContactNumber.Text);
                    SqlParameter Name = new SqlParameter("@Name", txtName.Text);

                    Session["UserName"] = txtUserName.Text;

                    cmd.Parameters.Add(UserName);
                    cmd.Parameters.Add(Password);
                    cmd.Parameters.Add(Email);
                    cmd.Parameters.Add(ContactNumber);
                    cmd.Parameters.Add(Name);

                    con.Open();
                    int ReturnCount = (int)cmd.ExecuteScalar();
                    if (ReturnCount == 1)
                    {
                        Response.Write("User or Email Already exist");
                    }
                    else
                    {
                        ConfirmationEmail();
                        Response.Redirect("~/USER_PANEL/Login.aspx?EmailVerification=A mail Has Been Send To Your Address.Please Verify It To Continue");
                    }
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

        private void ConfirmationEmail()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string ActivationCode = "";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select ActivationCode from tblUserInformation where UserName=@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                con.Open();
                ActivationCode = cmd.ExecuteScalar().ToString();

            }

            using (MailMessage mailmessage = new MailMessage("ucancallmeakshay@gmail.com", txtEmail.Text))
            {
                String a = Request.Url.AbsoluteUri.Replace("SignUp", "EmailVerification.aspx?ActivationCode=" + ActivationCode);
                mailmessage.Subject = "Email Verication For Your ALX Account";
                string body = "Hello " + txtUserName.Text;
                body += "<br />  Please Follow the bellow link to verify your account";
                body += "<br /> <a href='" + Request.Url.AbsoluteUri.Replace("Signup", "EmailVerification.aspx?ActivationCode=" + ActivationCode) + "' >Click here to activate your account</a>";
                body += "<br/ >Thanks";
                mailmessage.Body = body;
                mailmessage.IsBodyHtml = true;
                SmtpClient smptclient = new SmtpClient("smtp.gmail.com", 587);
                smptclient.EnableSsl = true;
                smptclient.Credentials = new System.Net.NetworkCredential("ucancallmeakshay@gmail.com", "akshay123");
                smptclient.Send(mailmessage);
            }

        }

    }
}