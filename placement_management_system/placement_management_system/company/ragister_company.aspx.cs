using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace placement_management_system.company
{
    public partial class ragister_company : System.Web.UI.Page
    {

        String abcd;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                hide_key.InnerHtml = "";
                form_after_pass_verification.Visible = false;
                pass_verification.Visible = true;
            }

        }
        
        protected void go_btn_click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load(Server.MapPath("~/admin/admin.xml"));
            var pass = xdoc.Element("admin").Element("company_reg_pass").Value;
            if (pass == apass.Value.ToString())
            {
                hide_key.InnerHtml = @"<input type='hidden' name='key' id='key' runat='server' value='SNK.bhimani3' />";
                form_after_pass_verification.Visible = true;
                pass_verification.Visible = false;
            }
        }

        protected void reg_btn_Click(object sender, EventArgs e)
        {
            String selected_branches = "";
            List<string> brnchs = branches.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();
            
            foreach (var item in brnchs)
            {
                selected_branches += "," + item;
            }
            if (!selected_branches.Equals(","))
            {


                String _name = cname.Value;
                String _description = description.Value;
                String _job_post = job_post.Value;
                String _job_salary = job_salary.Value;
                String _job_location = job_location.Value;
                String _other_details = other_details.Value;
                String _email = email.Value;
                String _phone = phone.Value;
                String _min_cpi = min_cpi.Value;
                String _password = password.Value;
                String _cpassword = cpassword.Value;
                //String _key = key.Value;
                if (_password == _cpassword)
                {

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select count(*) from company_table where email = '" + _email + "'";
                    int cnt = (int)cmd.ExecuteScalar();
                    if (cnt == 0)
                    {
                        cmd.CommandText = "INSERT INTO company_table (company_name, description, other_details, required_min_cpi, job_post, job_location, tentative_salary, email, phone, password,required_branches) values ('" + _name + "','" + _description + "','" + _other_details + "','" + _min_cpi + "','" + _job_post + "','" + _job_location + "','" + _job_salary + "','" + _email + "','" + _phone + "','" + _password + "', '" + selected_branches + "')";
                        cmd.ExecuteNonQuery();

                        company_id.Text = _email;
                        company_password.Text = _password;
                        reg_form.Visible = false;
                        after_reg.Visible = true;
                        cmd.Connection = con;
                        cmd.CommandText = "select * from student_table where cpi >= '" + _min_cpi + "'";
                        SqlDataReader reader = cmd.ExecuteReader();
                        NetworkCredential netCred = new NetworkCredential("snk.bhimani.jnd@gmail.com", "SNK.bhimani3");
                        SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 587);
                        smtpobj.EnableSsl = true;
                        smtpobj.Credentials = netCred;
                        while (reader.Read())
                        {
                            if (reader["email_id"].ToString() != null)
                            {
                                //MailMessage o = new MailMessage("snk.bhimani.jnd@gmail.com", reader["email_id"].ToString(), "placement management system", "Hello " + reader["full_name"] + ", <br><b>" + _name + "</b> company has registered in this system kaindly visit and find select if intrested if your branch is one of these: " + selected_branches + ".<br>-from placement management system");

                                //smtpobj.Send(o);
                            }

                        }
                        con.Close();
                    }
                    else
                    {
                        alert.InnerHtml = "<script>alert('This email address is already ragisterd. try forget password if you do not remember your password');</script>";
                    }

                }
                else
                {
                    alert.InnerHtml = "<script>alert('Password and Conform Password not matched');</script>";
                }

            }
            else
            {
                alert.InnerHtml = "<script>alert('select required branches');</script>";
            }
        }
    }
}