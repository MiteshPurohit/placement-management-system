using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.company
{
    public partial class start_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["company_id"] = "1";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from company_table where company_id = '" + Session["company_id"].ToString() + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            name.Text = reader["company_name"].ToString();

            reader.Close();
            cmd.CommandText = "SELECT * from company_table where company_id = '" + Session["company_id"].ToString() + "'";
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                String start = reader["start"].ToString();
                if (start.ToLower().Equals("true"))
                {
                    start_test_div.Visible = false;
                    stop_test_div.Visible = true;
                    complete_shedule_div.Visible = false;
                }
                else
                {
                    start_test_div.Visible = true;
                    stop_test_div.Visible = false;
                    complete_shedule_div.Visible = false;
                }

            }
            else
            {
                complete_shedule_div.Visible = true;
                start_test_div.Visible = false;
                stop_test_div.Visible = false;
            }
            

        }
        protected void start_test_click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE company_table set test_h='" + htime.Value.ToString() + "',test_m='" + mtime.Value.ToString() + "',start='true' where company_id = '" + Session["company_id"].ToString() + "'";
            
            cmd.ExecuteNonQuery();
            con.Close();
            start_test_div.Visible = false;
            stop_test_div.Visible = true;
            complete_shedule_div.Visible = false;
        }

        protected void stop_test_click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE company_table set start='false' where company_id = '" + Session["company_id"].ToString() + "'";
          
            cmd.ExecuteNonQuery();
            con.Close();
            start_test_div.Visible = true;
            stop_test_div.Visible = false;
            complete_shedule_div.Visible = false;
       
        }
       
    }
}