using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.IO;

namespace ALX.USER_PANEL
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

          

            if (Session["UserId"] == null)
            {
                Response.Redirect("~/USER_PANEL/Login.aspx");
            }
            else
            {
                //ulLogin.Controls.Add(new LiteralControl("<li>1</li>"));
                //ulLogin.Controls.Add(new LiteralControl("<li></li>"));
               



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
                

                //if (!IsPostBack)
                //{
                    string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    string a = Session["UserId"].ToString();
                    SqlDataAdapter da = new SqlDataAdapter("Select * FROM tblUserInformation Where UserId=" + Session["UserId"] + "", con);

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                    txtMail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtContactNumber.Text = ds.Tables[0].Rows[0]["ContactNumber"].ToString();
                    imgprofile.ImageUrl= ds.Tables[0].Rows[0]["ProfileImage"].ToString();
                //}
            }
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["UserId"] = null;
            ulLogin.Controls.RemoveAt(0);
            ulLogin.Controls.RemoveAt(1);
            ulLogin.Controls.RemoveAt(2);
            ulLogin.Controls.RemoveAt(3);
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

        protected void btnSearch1_Click(object sender, EventArgs e)    //...Search Button function
        {





            if (txtSearch.Text != "")
            {
                Response.Redirect("~/USER_PANEL/Products.aspx?Text=" + txtSearch.Text);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (ProfileImage.HasFile)
                {
                    string fileExtension = System.IO.Path.GetExtension(ProfileImage.FileName);
                    if (fileExtension.ToLower() != ".png" && fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".png" && fileExtension.ToLower() != ".jpeg")
                    {
                        lblFile.Text = "Please Select a Valid File Type";
                        lblFile.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        int fileSize = ProfileImage.PostedFile.ContentLength;
                        if (fileSize > 2097152)
                        {
                            lblFile.Text = "Please Select FileSize Less than 2MB";
                            lblFile.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            HttpPostedFile postedFile = ProfileImage.PostedFile;
                            string fileName = Path.GetFileName(postedFile.FileName);
                            ProfileImage.SaveAs(Server.MapPath("~/ImagesUpload/" + fileName));
                            SqlCommand cmd = new SqlCommand("UPDATE tblUserInformation SET ContactNumber=@ContactNumber, Name=@Name,ProfileImage=@ImageName where UserId = @USerId", con);
                            cmd.Parameters.AddWithValue("@USerID", Session["UserId"]);
                            cmd.Parameters.AddWithValue("@Name", txtName.Text);
                            cmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text);

                            cmd.Parameters.AddWithValue("@ImageName", "~/ImagesUpload/" + fileName);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            lblFile.Text = "";
                        }
                    }

                }
            }
            //string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con1 = new SqlConnection(cs);
            string a = Session["UserId"].ToString();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM tblUserInformation Where UserId=" + Session["UserId"] + "", con1);

            DataSet ds = new DataSet();
            da.Fill(ds);

            txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
            txtMail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtContactNumber.Text = ds.Tables[0].Rows[0]["ContactNumber"].ToString();
            imgprofile.ImageUrl = ds.Tables[0].Rows[0]["ProfileImage"].ToString();
            //}


        }

    }
}