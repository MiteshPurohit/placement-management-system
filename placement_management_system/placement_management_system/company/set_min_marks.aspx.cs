using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.company
{
    public partial class set_max_marks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Session["company_id"] as string))
            {
                Response.Redirect("company_login.aspx", true);
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from company_table where company_id = '" + Session["company_id"].ToString() + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (!IsPostBack)
            {
                min_marks.Text = reader["min_marks"].ToString();
            }
            name.Text = reader["company_name"].ToString();
            con.Close();
        }

        protected void set_marks_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update company_table set min_marks = '" + min_marks.Text + "' where company_id = '" + Session["company_id"].ToString() + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "update company_choice set selected='1' where company_id = '" + Session["company_id"].ToString() + "' and written_test_marks >= '" + min_marks.Text + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select * from student_table where student_id in (select student_id from company_choice where company_id = '" + Session["company_id"].ToString() + "' and selected='1')";
            SqlDataReader r = cmd.ExecuteReader();
            NetworkCredential netCred = new NetworkCredential("snk.bhimani.jnd@gmail.com", "SNK.bhimani3");
            SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 587);
            smtpobj.EnableSsl = true;
            smtpobj.Credentials = netCred;
            while (r.Read())
            {
                MailMessage o = new MailMessage("snk.bhimani.jnd@gmail.com", r["email_id"].ToString(), "placement management system", "Hello " + r["full_name"] + ", <br>Congratulations, You are selected for personal interview for <b>"+name.Text+"</b>. for more details open your account.<br>-from placement management system");

                smtpobj.Send(o);
            }
             cmd.CommandText = "select * from company_table where company_id = '" + Session["company_id"].ToString() + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
                min_marks.Text = reader["min_marks"].ToString();
            con.Close();
        }
    }
}