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

            if (!string.IsNullOrEmpty(Session["company_id"] as string))
            {
                Response.Redirect("company_login.aspx", true);
            }
            if (!IsPostBack)
            {

           
           
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from company_table where company_id = '" + Session["company_id"].ToString() + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            name.Text = reader["company_name"].ToString();

            cname.Text = reader["company_name"].ToString();
            branch.Text = reader["required_branches"].ToString();
            description.Text = reader["description"].ToString();
            job_post.Text = reader["job_post"].ToString();
            job_salary.Text = reader["tentative_salary"].ToString();
            job_location.Text = reader["job_location"].ToString();
            other_details.Text = reader["other_details"].ToString();
            email.Text = reader["email"].ToString();
            phone.Text = reader["phone"].ToString();
            min_cpi.Text = reader["required_min_cpi"].ToString();
           
            con.Close();
            }

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            String id = Session["company_id"].ToString();
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE company_table set other_details='" + other_details.Text.ToString() + "',job_post='" + job_post.Text.ToString() + "',job_location='" + job_location.Text.ToString() + "',tentative_salary='" + job_salary.Text.ToString() + "',company_name='" + cname.Text.ToString() + "', required_branches = '" + branch.Text.ToString().ToUpper() + "', description = '" + description.Text.ToString() + "', phone = '" + phone.Text.ToString() + "', required_min_cpi = '" + min_cpi.Text.ToString() + "', email = '" + email.Text.ToString() + "' where company_id = '" + id + "'";
            name.Text = cmd.CommandText;
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "SELECT * from company_table where company_id = '" + Session["company_id"].ToString() + "'";
            SqlDataReader reader = cmd1.ExecuteReader();
            reader.Read();
            name.Text = reader["company_name"].ToString();

            cname.Text = reader["company_name"].ToString();
            branch.Text = reader["required_branches"].ToString();
            description.Text = reader["description"].ToString();
            job_post.Text = reader["job_post"].ToString();
            job_salary.Text = reader["tentative_salary"].ToString();
            job_location.Text = reader["job_location"].ToString();
            other_details.Text = reader["other_details"].ToString();
            email.Text = reader["email"].ToString();
            phone.Text = reader["phone"].ToString();
            min_cpi.Text = reader["required_min_cpi"].ToString();
           
            con.Close();
            
        }
    }
}