using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI.HtmlControls;

namespace ALX.USER_PANEL
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            else
            {
                Response.Redirect("~/USER_PANEL/Login.aspx");
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["UserId"] = null;
            ulLogin.Controls.RemoveAt(1);
            ulLogin.Controls.RemoveAt(1);
            ulLogin.Controls.RemoveAt(1);
            ulLogin.Controls.RemoveAt(1);
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (fileuploadProducts.HasFile)
                {
                    string fileExtension = System.IO.Path.GetExtension(fileuploadProducts.FileName);
                    if (fileExtension.ToLower() != ".png" && fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".png" && fileExtension.ToLower() != ".jpeg")
                    {
                        lblFile.Text = "Please Select a Valid File Type";
                        lblFile.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        int fileSize = fileuploadProducts.PostedFile.ContentLength;
                        if (fileSize > 2097152)
                        {
                            lblFile.Text = "Please Select FileSize Less than 2MB";
                            lblFile.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {

                        HttpPostedFile postedFile = fileuploadProducts.PostedFile;
                        string fileName = Path.GetFileName(postedFile.FileName);
                        fileuploadProducts.SaveAs(Server.MapPath("~/ImagesUpload/" + fileName));
                        SqlCommand cmd = new SqlCommand("insert into tblProducts values(@ID,@price,@Category,@ProductName,@Description,@ImageName)", con);
                        cmd.Parameters.AddWithValue("@ID", Session["UserId"]);
                        cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                        cmd.Parameters.AddWithValue("@Category", DropDownList1.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@ProductName", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@ImageName", "~/ImagesUpload/" + fileName);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        txtTitle.Text = "";
                        txtDescription.Text = "";
                            lblFile.Text = "";
                            //Response.Write("Uploaded");
                        }

                    }
                }
                else
                {
                    lblFile.Text = "Please Select a File to Upload";
                    lblFile.ForeColor = System.Drawing.Color.Red;

                }

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