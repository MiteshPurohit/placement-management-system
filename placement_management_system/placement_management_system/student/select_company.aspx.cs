using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.student
{
    
    public partial class select_company : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["student_id"] == null)
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


            String selected = null;
            String company_name = null;
            String selary = null;
            String post = null;
            String location = null;
            String id = null;
            String sel = null;
            String text = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from company_table";
            SqlDataReader reader = cmd.ExecuteReader();
            LiteralControl imageGallery = new LiteralControl();
            while (reader.Read())
            {
                if (float.Parse(r["cpi"].ToString()) >= float.Parse(reader["required_min_cpi"].ToString()) && reader["required_branches"].ToString().Contains(r["branch"].ToString()))
                {
                    SqlCommand ccmd = new SqlCommand();
                    ccmd.Connection = con;
                    ccmd.CommandText = "SELECT * from company_choice where company_id='" + reader["company_id"].ToString() + "' and student_id='" + Session["student_id"].ToString() + "'";
                    SqlDataReader rdr = ccmd.ExecuteReader();
                    sel = "false";
                    selected = "";
                    text = "select";
                    if (rdr.Read())
                    {
                        text = "remove";
                        selected = "selected";
                        sel = "true";
                    }
                    company_name = reader["company_name"].ToString();
                    selary = reader["tentative_salary"].ToString();
                    post = reader["job_post"].ToString();
                    location = reader["job_location"].ToString();
                    id = reader["company_id"].ToString();

                    String str = String.Format(@"<li id='companies' runat='server'>
            <div class='collapsible-header'><span class='new badge' data-badge-caption='{0}'></span><b>{1}</b></div><div class='collapsible-body'><table class='striped'><tr><td  style='padding-left:6%;'>Expected Job Post</td><td>{2}</td></tr><tr><td style='padding-left:6%;'>Expected Annual Job Selary</td><td>{3} $</td></tr><tr><td style='padding-left:6%;'>Expected Job Location</td><td>{4}</td></tr><tr><td style='padding-left:6%;'><a class='waves-effect waves-light btn' href='view_company_details.aspx?id={5}&src=select'>view more details</a></td><td><a class='waves-effect waves-light btn' href='_select_company.aspx?id={6}&select={7}'>{8}<a/></td></tr></table></div></li>", selected, company_name, post, selary, location, id, id, sel, text);
                    imageGallery.Text += str;

                }
                this.companies.Controls.Add(imageGallery);
            }

            con.Close();
        }
    }
}