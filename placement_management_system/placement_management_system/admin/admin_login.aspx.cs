using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace placement_management_system
{
    public partial class admin_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login_btn_click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load(Server.MapPath("~/admin/admin.xml"));
            var username = xdoc.Element("admin").Element("username").Value;
            var password = xdoc.Element("admin").Element("password").Value;
            if ((String)username == admin_username.Text.ToString() && (String)password == pass.Text.ToString())
            {
                Response.Redirect("admin_home.aspx");
            }
            Console.Write(username + " " + password);
        }
    }
}