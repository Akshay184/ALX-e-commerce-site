using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ALX.ADMIN_PANEL
{
    public partial class adminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Session["AdminId"]) != 1)
                {
                    Response.Redirect("~/ADMIN_PANEL/AdminLogin.aspx");
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["AdminId"] = "";
            Response.Redirect("~/ADMIN_PANEL/AdminLogin.aspx");
        }
    }
}