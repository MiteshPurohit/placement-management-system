using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.student
{
    public partial class view_company_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["student_id"] == null)
            {
                Response.Redirect("student_login.aspx", true);
            }
            string id = Request.QueryString["id"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
            con.Open();
            SqlCommand c = new SqlCommand();
            c.Connection = con;
            c.CommandText = "SELECT * from student_table where student_id = '" + Session["student_id"].ToString() + "'";
            SqlDataReader r = c.ExecuteReader();
            r.Read();
            name.Text = r["full_name"].ToString();
            SqlCommand ccmd = new SqlCommand();
                ccmd.Connection = con;
                ccmd.CommandText = "SELECT * from company_table where company_id='" + id + "'";
                SqlDataReader rdr = ccmd.ExecuteReader();
                if (rdr.Read())
                {
                    //String branch = null;
                    //String[] b = rdr["required_branches"].ToString().Split(',');
                    //for (int i = 1; i <= b.Length; i++)
                    //{
                     //   branch += b[i];
                    //}
                    cname.InnerHtml += rdr["company_name"].ToString();
                    description.InnerHtml += rdr["description"].ToString();
                    post.InnerHtml += rdr["job_post"].ToString();
                    cpi.InnerHtml += rdr["required_min_cpi"].ToString();
                    branchs.InnerHtml += rdr["required_branches"].ToString();
                    location.InnerHtml += rdr["job_post"].ToString();
                    salary.InnerHtml += rdr["tentative_salary"].ToString();
                    details.InnerHtml += rdr["other_details"].ToString();
                }
                if (Request.QueryString["src"]=="select")
                {
                    btn.InnerHtml += "<a class='waves-effect waves-light btn' href='select_company.aspx'>back<a/>";
                }
                else
                {
                    btn.InnerHtml += "<a class='waves-effect waves-light btn' href='view_company.aspx'>back<a/>";
                }
        }
    }
}