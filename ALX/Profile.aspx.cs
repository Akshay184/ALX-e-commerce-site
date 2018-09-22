using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ALX
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select Username,Email,ContactNumber from UserInformation where UserId=@ID",con);
                cmd.Parameters.AddWithValue("@ID", Session["Id"]);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("insert into tblProducts values(@ID,@price,@Category,@ProductName)", con);
                cmd.Parameters.AddWithValue("@ID", Session["Id"]);
                cmd.Parameters.AddWithValue("@Price", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Category",DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@ProductName", TextBox3.Text);
                con.Open();
                cmd.ExecuteScalar();
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
        }
    }
}