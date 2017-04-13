using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace placement_management_system.admin
{
    public partial class change_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin_id"] == null)
            {
                Response.Redirect("admin_login.aspx", true);
            }
        }
        protected void _change_password(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load(Server.MapPath("~/admin/admin.xml"));
            var pass = xdoc.Element("admin").Element("password").Value;
            if (new_pass.Text.Equals(confirm_new_pass.Text) && pass.Equals(old_pass.Text))
            {
                xdoc.Element("admin").Element("password").Value = new_pass.Text;
                xdoc.Save(Server.MapPath("~/admin/admin.xml"));
                alert.InnerHtml = "<script>alert('Password has been changed successfully :)');</script>";
            }
            else
            {
                alert.InnerHtml = "<script>alert('Password has not been changed :[ ');</script>";
            }
        }
    }
}