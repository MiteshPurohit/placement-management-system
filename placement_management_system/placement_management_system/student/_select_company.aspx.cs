using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.student
{
    public partial class _select_company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string buttonId = Request.QueryString["id"];
            string select = Request.QueryString["select"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
            con.Open();
            if (select == "false")
            {
                SqlCommand ccmd = new SqlCommand();
                ccmd.Connection = con;
                ccmd.CommandText = "SELECT * from company_choice where company_id='" + buttonId + "' and student_id='" + Session["student_id"].ToString() + "'";
                SqlDataReader rdr = ccmd.ExecuteReader();
                if (!rdr.Read())
                {
                    SqlCommand c = new SqlCommand();
                    c.Connection = con;
                    c.CommandText = "SELECT * from student_table where student_id = '1'";
                    SqlDataReader r = c.ExecuteReader();
                    r.Read();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * from company_table where company_id='" + buttonId + "'";
                    SqlDataReader reader = cmd.ExecuteReader();
                    String s;
                    if (reader.Read())
                    {
                        if (float.Parse(r["cpi"].ToString()) >= float.Parse(reader["required_min_cpi"].ToString()) && reader["required_branches"].ToString().Contains(r["branch"].ToString()))
                        {
                            SqlCommand wcmd = new SqlCommand();
                            wcmd.Connection = con;
                            wcmd.CommandText = "INSERT INTO company_choice (student_id, company_id) values('" + Session["student_id"].ToString() + "','" + buttonId + "')";
                            wcmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            else if (select == "true")
            {
                SqlCommand ccmd = new SqlCommand();
                ccmd.Connection = con;
                ccmd.CommandText = "DELETE from company_choice where company_id='" + buttonId + "' and student_id='" + Session["student_id"].ToString() + "'";
                ccmd.ExecuteNonQuery();
            }
            con.Close();
            Response.Redirect("select_company.aspx");

        }
    }
}