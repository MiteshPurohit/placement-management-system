using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.student
{
    public partial class set_viewstate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["student_id"] == null)
            {
                Response.Redirect("student_login.aspx", true);
            }
            double abcd;
            if (string.IsNullOrEmpty(Request.QueryString["id"] as string) && double.TryParse(Request.QueryString["id"], out abcd))
            {
                Response.Redirect("select_company_for_test.aspx", true);
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["pmsdbConnectionString"].ConnectionString;

            con.Open();
            SqlCommand c = new SqlCommand();
            c.Connection = con;
            c.CommandText = "SELECT COUNT(*) from company_table where company_id in (select company_id from company_choice where student_id = '" + Session["student_id"].ToString() + "') and company_id in (select company_id from company_table where start = 'True')";
            if ((int)c.ExecuteScalar() != 0)
            {
                Session["company_id"] = Request.QueryString["id"];
            }

            Response.Redirect("test.aspx");
            
        }
    }
}