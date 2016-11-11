using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.company
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["company_id"] as string))
            {
                Response.Redirect("company_login.aspx", true);
            }
            Session.Clear();
            Session.Abandon();
            Response.Redirect("company_login.aspx", true);
        }
    }
}