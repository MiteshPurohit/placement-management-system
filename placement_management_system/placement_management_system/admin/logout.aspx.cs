using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.admin
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["admin_id"] as string))
            {
                Response.Redirect("admin_login.aspx", true);
            }
            Session.Clear();
            Session.Abandon();
            Response.Redirect("admin_login.aspx", true);
        }
    }
}