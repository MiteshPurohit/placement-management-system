using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.student
{
    public partial class select_company_for_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["student_id"] == null)
            {
                Response.Redirect("student_login.aspx", true);
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
            con.Open();
            SqlCommand c = new SqlCommand();
            c.Connection = con;
            c.CommandText = "SELECT * from student_table where student_id = '" + Session["student_id"].ToString() + "'";
            SqlDataReader r = c.ExecuteReader();
            r.Read();
            name.Text = r["full_name"].ToString();
            r.Close();

            c.CommandText = "SELECT company_id, company_name from company_table where company_id in (select company_id from company_choice where student_id = '" + Session["student_id"].ToString() + "') and company_id in (select company_id from company_table where start = 'True')";
            r = c.ExecuteReader();
            
            
            String template = @"<a href='set_viewstate.aspx?id={0}' class='collection-item'>{1}</a>";
            while (r.Read())
            {
                company_list.InnerHtml += String.Format(template, r["company_id"], r["company_name"]);
            }

        }
    }
}