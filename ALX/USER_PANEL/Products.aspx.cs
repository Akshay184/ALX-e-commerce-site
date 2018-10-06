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
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {


                rptProducts.DataSource = GetData();
                rptProducts.DataBind();

                try
                {

                    Search();
                }
                catch
                {

                }

            }
            if (Session["UserId"] != null)
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

        protected void AddToCart(object sender, CommandEventArgs e)
        {
            if (Session["UserId"] != null)
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
           
        }

        protected void Description(object sender, CommandEventArgs e)
        {
            string Description = e.CommandArgument.ToString();
            Response.Redirect("~/USER_PANEL/Description.aspx?ProductId="+Description);
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

        protected DataSet GetData()
        {
            try
            {
                string Category = Request.QueryString["Category"].ToString();
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlDataAdapter da = new SqlDataAdapter("Select * from tblProducts where CATEGORY=@Category", con);
                da.SelectCommand.Parameters.AddWithValue("@Category", Category);
                DataSet ds = new DataSet();
                da.Fill(ds);
                rptProducts.DataSource = ds;
                rptProducts.DataBind();
                return ds;
            }
            catch
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlDataAdapter da = new SqlDataAdapter("Select * from tblProducts ", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                rptProducts.DataSource = ds;
                rptProducts.DataBind();
                return ds;
            }

        }
        protected void btnSearch1_Click(object sender, EventArgs e)    //...Search Button function
        {





            if (txtSearch.Text != "")
            {
                Response.Redirect("~/USER_PANEL/Products.aspx?Text=" + txtSearch.Text);
            }
        }

        protected DataSet Search()
        {
            DataSet ds = new DataSet();
            try
            {


                String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                string SearchText = Request.QueryString["Text"].ToString();
               
                SqlDataAdapter da = new SqlDataAdapter("Select * from tblProducts where ProductName like '%' + @ProductName + '%' Order BY price ASC", con);

                da.SelectCommand.Parameters.AddWithValue("ProductName", SearchText);
                da.Fill(ds);
                rptProducts.DataSource = ds;
                rptProducts.DataBind();
                return ds;
            }
            catch
            {
                return ds;
            }
        }



        //if (DropDownListFilters.SelectedValue == "0")
        //{
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter("Select * from tblProducts where ProductName like '%' + @ProductName + '%'", con);

        //    da.SelectCommand.Parameters.AddWithValue("ProductName", txtSearch.Text);
        //    da.Fill(ds);
        //    rptProduct.DataSource = ds;
        //    rptProduct.DataBind();
        //}
        //else if (DropDownListFilters.SelectedValue == "1")
        //{
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter("Select * from tblProducts where ProductName like '%' + @ProductName + '%' Order BY price DESC", con);

        //    da.SelectCommand.Parameters.AddWithValue("ProductName", txtSearch.Text);
        //    da.Fill(ds);
        //    rptProduct.DataSource = ds;
        //    rptProduct.DataBind();
        //}
        //else
        //{


        //}

        //else
        //{

        //}
    }


}