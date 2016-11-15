using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin_id"] == null)
            {
                Response.Redirect("admin_login.aspx", true);
            }
        }

       
        private void Page_Error(object sender, EventArgs e)
        {
            alert.InnerHtml = "<script>Invalid details entered</script>";
            Server.TransferRequest("../error.aspx");
        }
    }
}