using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ALX.USER_PANEL
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/USER_PANEL/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    rptProducts.DataSource = GetData();
                    rptProducts.DataBind();
                }
              
            }

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
    }


}