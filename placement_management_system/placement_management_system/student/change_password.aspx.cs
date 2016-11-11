using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.student
{
    public partial class change_password : System.Web.UI.Page
    {
        string pass;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["student_id"] as string))
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
            pass = r["password"].ToString();
            con.Close();
        }
        protected void _change_password(object sender, EventArgs e)
        {
            if (new_pass.Text.Equals(confirm_new_pass.Text) && pass.Equals(old_pass))
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
                con.Open();
                SqlCommand c = new SqlCommand();
                c.Connection = con;
                c.CommandText = "update student_table set password='"+new_pass.Text+"' where student_id = '" + Session["student_id"].ToString() + "'";
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