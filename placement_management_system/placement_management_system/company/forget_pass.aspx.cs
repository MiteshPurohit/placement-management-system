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
    public partial class forget_pass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void send_password(object sender, EventArgs e)
        {
            if (company_id.Text != null)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
                con.Open();
                SqlCommand c = new SqlCommand();
                c.Connection = con;
                c.CommandText = "select * from company_table where email='" + company_id.Text + "'";
                SqlDataReader reader = c.ExecuteReader();
                reader.Read();

                //MailMessage o = new MailMessage("snk.bhimani.jnd@gmail.com", reader["email"].ToString(), "Your password for placement management system", "Respected sir/mam,<br><p>Your password is: " + reader["password"].ToString() + "</p><br>from placement management system");
                //o.IsBodyHtml = true;
                NetworkCredential netCred = new NetworkCredential("snk.bhimani.jnd@gmail.com", "SNK.bhimani3");
                SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 587);
                smtpobj.EnableSsl = true;
                smtpobj.Credentials = netCred;
                //smtpobj.Send(o);
                con.Close();
                alert.InnerHtml = "<script>alert('Your password has been sent to your email address');</script>";
            }
            else
            {
                alert.InnerHtml = "<script>alert('Enter Email address first');</script>";
            }
        }
        
    }
}