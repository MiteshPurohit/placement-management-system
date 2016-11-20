using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.student
{
    public partial class forget_pass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void send_password(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(student_id.Text))
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["pmsdbConnectionString"].ConnectionString;

                con.Open();
                SqlCommand c = new SqlCommand();
                c.Connection = con;
                c.CommandText = "select * from student_table where email='" + student_id.Text + "'";
                SqlDataReader reader = c.ExecuteReader();
                reader.Read();

                //MailMessage o = new MailMessage("snk.bhimani.jnd@gmail.com", reader["email_id"].ToString(), "Your password for placement management system", "Hello "+reader["full_name"]+",<br><p>Your password is: " + reader["password"].ToString() + "</p><br>from placement management system");
                NetworkCredential netCred = new NetworkCredential("snk.bhimani.jnd@gmail.com", "SNK.bhimani3");
                SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 587);
                smtpobj.EnableSsl = true;
                smtpobj.Credentials = netCred;
                //smtpobj.Send(o);
                con.Close();
                alert.InnerHtml = "<script>alert('Your password has been sent to your email address. If you have not entered email address to the system then contact admin');</script>";
            }
        }
    }
}