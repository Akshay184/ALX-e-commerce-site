using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ALX.USER_PANEL
{
    public partial class ALXHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["UserId"] == null)
            {
                //Response.Redirect("~/USER_PANEL/Login.aspx");
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
                anchor2.Attributes.Add("href", "#");
                anchor2.InnerText = "Profile";
                li2.Controls.Add(anchor2);

                HtmlGenericControl li3 = new HtmlGenericControl("li");
                ulLogin.Controls.Add(li3);
                HtmlGenericControl anchor3 = new HtmlGenericControl("a");
                anchor3.Attributes.Add("href", "Products.aspx");
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

    }
}