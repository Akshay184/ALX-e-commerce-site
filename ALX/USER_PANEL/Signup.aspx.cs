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
using System.Web.UI.HtmlControls;

namespace ALX.USER_PANEL
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                Response.Redirect("~/USER_PANEL/ALXHome.aspx");
            }
            lblSignup.Text = "";
            if(Session["UserId"] != null)
            {
                


                    HtmlGenericControl li1 = new HtmlGenericControl("li");
                    ulLogin.Controls.Add(li1);
                    HtmlGenericControl anchor1 = new HtmlGenericControl("a");
                    anchor1.Attributes.Add("href", "AddProduct.aspx");
                    anchor1.InnerText = "Sell";
                    li1.Controls.Add(anchor1);

                    HtmlGenericControl li2 = new HtmlGenericControl("li");
                    ulLogin.Controls.Add(li2);
                    HtmlGenericControl anchor2 = new HtmlGenericControl("a");
                    anchor2.Attributes.Add("href", "EditProfile");
                    anchor2.InnerText = "Profile";
                    li2.Controls.Add(anchor2);

                    HtmlGenericControl li3 = new HtmlGenericControl("li");
                    ulLogin.Controls.Add(li3);
                    HtmlGenericControl anchor3 = new HtmlGenericControl("a");
                    anchor3.Attributes.Add("href", "Account.aspx");
                    anchor3.InnerText = "Account";
                    li3.Controls.Add(anchor3);

                    HtmlGenericControl li4 = new HtmlGenericControl("li");
                    ulLogin.Controls.Add(li4);
                    LinkButton link = new LinkButton();
                    link.Text = "Logout";
                    link.ID = "lnkLogout";
                    link.Click += new System.EventHandler(lnkLogout_Click);
                    li4.Controls.Add(link);
                
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["UserId"] = null;
            ulLogin.Controls.RemoveAt(0);
            ulLogin.Controls.RemoveAt(1);
            ulLogin.Controls.RemoveAt(2);
            ulLogin.Controls.RemoveAt(3);
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
                       lblSignup.Text="UserName Or Email Already Exists";
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
                SqlDataAdapter da = new SqlDataAdapter("select ActivationCode, UserID from tblUserInformation where UserName = @UserName", con);
                da.SelectCommand.Parameters.AddWithValue("@UserName", Session["UserName"]);
                DataSet ds = new DataSet();
                da.Fill(ds);

                con.Open();
                ActivationCode = ds.Tables[0].Rows[0]["ActivationCode"].ToString();
                string User = ds.Tables[0].Rows[0]["UserId"].ToString();

            }

            using (MailMessage mailmessage = new MailMessage("ucancallmeakshay@gmail.com", txtEmail.Text))
            {
                String a = Request.Url.AbsoluteUri.Replace("SignUp", "EmailVerification.aspx?ActivationCode=" + ActivationCode);
                mailmessage.Subject = "Email Verication For Your ALX Account";
                string body = "Hello " + txtUserName.Text;
                body += "<br />  Please Follow the bellow link to verify your account";
                body += "<br /> <a href='" + Request.Url.AbsoluteUri.Replace("Signup", "Login.aspx?ActivationCode=" + ActivationCode ) + "' >Click here to activate your account</a>";
                body += "<br/ >Thanks";
                mailmessage.Body = body;
                mailmessage.IsBodyHtml = true;
                SmtpClient smptclient = new SmtpClient("smtp.gmail.com", 587);
                smptclient.EnableSsl = true;
                smptclient.Credentials = new System.Net.NetworkCredential("ucancallmeakshay@gmail.com", "akshay123");
                smptclient.Send(mailmessage);
            }

        }
        protected void btnSearch1_Click(object sender, EventArgs e)    //...Search Button function
        {





            if (txtSearch.Text != "")
            {
                Response.Redirect("~/USER_PANEL/Products.aspx?Text=" + txtSearch.Text);
            }
        }


    }
}