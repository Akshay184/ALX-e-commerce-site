using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
namespace ALX
{
    public partial class editProfile : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlDataAdapter da = new SqlDataAdapter("Select UserName,Email,ContactNumber FROM UserInformation Where UserId=" + Session["ID"] + "", con);

                DataSet ds = new DataSet();
                da.Fill(ds);

                txtUsername.Text = ds.Tables[0].Rows[0]["Username"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtEditContacct.Text = ds.Tables[0].Rows[0]["ContactNumber"].ToString();
            }
        }
     
        protected void txtEditContacct_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UPDATE UserInformation SET ContactNumber="+txtEditContacct.Text+" WHERE UserId=" + Session["ID"] + ";", con);
                // cmd.Parameters.AddWithValue("@ID", Session["Id"]);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Write("Details Updated");
        }

        protected void txtUsername_TextChanged(object sender, EventArgs e)
        {   
            txtUsername.Attributes.Add("readonly", "readonly");

        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.Attributes.Add("readonly", "readonly");
        }
    }
}