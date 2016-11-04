using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.company
{
    public partial class edit_details : System.Web.UI.Page
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

            cname.Value = reader["company_name"].ToString();
            branch.Value = reader["required_branches"].ToString();
            description.Value = reader["description"].ToString();
            job_post.Value = reader["job_post"].ToString();
            job_salary.Value = reader["tentative_salary"].ToString();
            job_location.Value = reader["job_location"].ToString();
            other_details.Value = reader["other_details"].ToString();
            email.Value = reader["email"].ToString();
            phone.Value = reader["phone"].ToString();
            min_cpi.Value = reader["required_min_cpi"].ToString();
           
            con.Close();

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            String id = "1";
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE company_table set other_details='" + other_details.Value.ToString() + "',job_post='" + job_post.Value.ToString() + "',job_location='" + job_location.Value.ToString() + "',tentative_salary='" + job_salary.Value.ToString() + "',company_name='" + cname.Value.ToString() + "', required_branches = '" + branch.Value.ToString().ToUpper() + "', description = '" + description.Value.ToString() + "', phone = '" + phone.Value.ToString() + "', required_min_cpi = '" + min_cpi.Value.ToString() + "', email = '" + email.Value.ToString() + "' where company_id = '" + id + "'";
            name.Text = cmd.CommandText;
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
    }
}