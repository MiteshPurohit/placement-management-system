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
            Session["student_id"] = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
            con.Open();
            SqlCommand c = new SqlCommand();
            c.Connection = con;
            c.CommandText = "SELECT COUNT(*) from company_table where company_id in (select company_id from company_choice where student_id = '" + Session["student_id"].ToString() + "') and company_id in (select company_id from schedule where start = 'True')";
            if ((int)c.ExecuteScalar() != 0)
            {
                Session["company_id"] = Request.QueryString["id"];
            }

            Response.Redirect("test.aspx");
            
        }
    }
}