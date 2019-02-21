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

namespace ALX.USER_PANEL
{
    public partial class Description : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/USER_PANEL/Login.aspx");
            }
            else
            {

                DataSet ds = new DataSet();

                ds = GetData();
                lblDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                lblProductName.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();
                lblPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                imgPic.ImageUrl = ds.Tables[0].Rows[0]["images"].ToString();
                btnAddToCart.CommandArgument = ds.Tables[0].Rows[0]["ProductId"].ToString();
                btnContactNumber.Text = ds.Tables[0].Rows[0]["ContactNumber"].ToString();
                btnEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            }

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


        protected void AddToCart(object sender, CommandEventArgs e)
        {
            string CurrentProductId = e.CommandArgument.ToString();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("insert into tblAddToCart values(@ProductID,@UserID)", con);
                cmd.Parameters.AddWithValue("@ProductID", CurrentProductId);
                cmd.Parameters.AddWithValue("@UserID", Session["UserId"]);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        protected DataSet GetData()
        {
            string ProductId =   Request.QueryString["ProductId"].ToString();
            //string  ProductId = "8";
            //string Category = Request.QueryString["Category"].ToString();
            string query = "select * from tblProducts inner join tblUserInformation on tblProducts.UserId = tblUserInformation.UserID where tblProducts.ProductId = @ProductId";
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@ProductId", ProductId);
            DataSet ds = new DataSet();
            da.Fill(ds);
           
            return ds;
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