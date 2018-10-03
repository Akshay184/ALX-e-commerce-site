using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace ALX
{
    public partial class EmailVerification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ActivationCode = Request.QueryString["ActivationCode"];
                string Code = "";
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))

                {
                    SqlCommand cmd = new SqlCommand("Select ActivationCode from tblUserInformation where UserName = @UserName",con);
                    cmd.Parameters.AddWithValue("@UserName", Session["UserName"]);
                    con.Open();
                    Code = cmd.ExecuteScalar().ToString();
                }
                if (String.Equals(Code, ActivationCode))
                {
                    Response.Write("Verified");
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("update tblUserInformation set EmailVerified=1  where UserName=@UserName",con);
                        cmd.Parameters.AddWithValue("@UserName", Session["UserName"]);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    Response.Write("Not Verified");
                }
            }
          
        }
    }
}