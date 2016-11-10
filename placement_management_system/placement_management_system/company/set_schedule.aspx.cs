using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.company
{
    public partial class set_schedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            Session["company_id"] = '1';
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
            con.Open();
            SqlCommand ccmd = new SqlCommand();
            ccmd.Connection = con;
            ccmd.CommandText = "update company_table set tentative_interview_date = '" + interview_date.Text + "', tentative_written_test_date = ''" + test_date .Text+ "' where company_id='" + Session["company_id"].ToString() + "'";
            ccmd.ExecuteNonQuery();
            con.Close();
        }
    }
}