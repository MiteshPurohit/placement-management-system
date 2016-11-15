using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.company
{
    public partial class change_password : System.Web.UI.Page
    {
        string pass; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["company_id"] == null)
            {
                Response.Redirect("company_login.aspx", true);
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
            con.Open();
            SqlCommand c = new SqlCommand();
            c.Connection = con;
            c.CommandText = "SELECT * from company_table where company_id = '" + Session["company_id"].ToString() + "'";
            SqlDataReader r = c.ExecuteReader();
            r.Read();
            name.Text = r["company_name"].ToString();
            pass = r["password"].ToString();
            con.Close();
        }
        protected void _change_password(object sender, EventArgs e)
        {
            if (new_pass.Text.Equals(confirm_new_pass.Text) && pass.Equals(old_pass.Text))
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
                con.Open();
                SqlCommand c = new SqlCommand();
                c.Connection = con;
                c.CommandText = "update company_table set password='" + new_pass.Text + "' where company_id = '" + Session["company_id"].ToString() + "'";
                c.ExecuteNonQuery();
                con.Close();
                alert.InnerHtml = "<script>alert('Password has been changed successfully :)');</script>";
            }
            else
            {
                alert.InnerHtml = "<script>alert('Password has not been changed :[ ');</script>";
            }
        }
        
    }
}