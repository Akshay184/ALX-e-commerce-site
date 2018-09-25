using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ALX
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(Convert.ToInt32(Session["ID"])==0)
            {
                Response.Redirect("~/LogIn.aspx");
            }
            Response.Write(Session["Id"]);
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["ID"]= 0;
            Response.Redirect("~/LogIn.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = GetData("Furniture");
            rptProduct.DataSource = ds;
            rptProduct.DataBind();
        }

        private DataSet GetData(string category)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select ProductName,Price,Description,images from tblProducts where CATEGORY='"+category+"'", con);
                
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile.aspx");
        }

        protected void btnBooks_Click(object sender, EventArgs e)
        {
            DataSet ds = GetData("Books");
            rptProduct.DataSource = ds;
            rptProduct.DataBind();
        }

        protected void btnElectronics_Click(object sender, EventArgs e)
        {
            DataSet ds = GetData("Electronics");
            rptProduct.DataSource = ds;
            rptProduct.DataBind();
        }
    }
}