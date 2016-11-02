using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system
{
    public partial class student_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login_btn_click(object sender, EventArgs e)
        {
            if (clg_id.Text.ToString() == pass.Text.ToString())
            {
                Response.Redirect("student_home.aspx");
            }
        }
    }
}