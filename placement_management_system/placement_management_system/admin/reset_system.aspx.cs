using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.admin
{
    public partial class reset_system : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin_id"] == null)
            {
                Response.Redirect("admin_login.aspx", true);
            }
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["pmsdbConnectionString"].ConnectionString;
            
            con.Open();
            SqlCommand cmd = new SqlCommand();
            if (reset_text.Text.Equals("RESET"))
            {
                cmd.Connection = con;
                cmd.CommandText = @"DELETE FROM student_test_data;
                                    DBCC CHECKIDENT(student_test_data, reseed, 0);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"DELETE FROM company_choice;
                                    DBCC CHECKIDENT(company_choice, reseed, 0);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"DELETE FROM question_table;
                                    DBCC CHECKIDENT(question_table, reseed, 0);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"DELETE FROM company_table;
                                    DBCC CHECKIDENT(company_table, reseed, 0);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"DELETE FROM student_table;
                                    DBCC CHECKIDENT(student_table, reseed, 0);";
                cmd.ExecuteNonQuery();
                reset_div.InnerHtml = "<h3>done!</h3>";
            }
            else
            {
                reset_div.InnerHtml = "<h3>System has not reset</h3>";
            }
            
        }
    }
}