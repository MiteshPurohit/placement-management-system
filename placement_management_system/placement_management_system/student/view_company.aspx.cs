using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.student
{
    public partial class view_company : System.Web.UI.Page
    {
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

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from company_table";
            SqlDataReader reader = cmd.ExecuteReader();
            LiteralControl imageGallery = new LiteralControl();
            while (reader.Read())
            {
                if (float.Parse(r["cpi"].ToString()) >= float.Parse(reader["required_min_cpi"].ToString()) && reader["required_branches"].ToString().Contains(r["branch"].ToString()))
                {
                    String str = String.Format(@"<a href='view_company_details.aspx?src=view&id={0}' class='collection-item'>{1}</a>", reader["company_id"], reader["company_name"]);
                    list.InnerHtml += str;
                }
            }

        }
    }
}