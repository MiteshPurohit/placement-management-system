using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.student
{
    public partial class write_question : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["student_id"] == null)
            {
                Response.Redirect("student_login.aspx", true);
            }
            if (!Session["start_test"].ToString().Equals("true"))
            {
                Response.Redirect("select_company_for_test.aspx", true);
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
            con.Open();
            SqlCommand c = new SqlCommand();
            c.Connection = con;
            c.CommandText = "update company_choice set written_test_given = 'true' where student_id = '" + Session["student_id"].ToString() + "' and company_id = '" + Session["company_id"].ToString() + "'";
            c.ExecuteNonQuery();
            List<string> listkeys = new List<string>();
            foreach (string key in Request.Form.AllKeys)
            {

                if (key.StartsWith("snk"))
                {
                    
                   
                    listkeys.Add(key.Replace("snk", ""));
                }
                

            }
            foreach (var key in listkeys)
            {
                string ans = (string)Request.Form["snk"+key];

                Console.Write(key);
                SqlDataReader r;
                
                    c.CommandText = "select * from question_table where question_id = '" + key + "'";
                    r = c.ExecuteReader();
                    r.Read();


                    if (r["choice_ans"].ToString().ToLower().Equals(ans.ToLower()))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "insert into student_test_data (question_id, student_id, mcq_choice, true_false) values('" + key + "', '" + Session["student_id"] + "','" + ans + "','true')";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "insert into student_test_data (question_id, student_id, mcq_choice, true_false) values('" + key + "', '" + Session["student_id"] + "','" + ans + "','false')";
                        cmd.ExecuteNonQuery();
                    }
                    r.Close();
                }
            SqlCommand ccmd = new SqlCommand();
            ccmd.Connection = con;
            ccmd.CommandText = "select COUNT(*) from student_test_data where student_id = '" + Session["student_id"] + "' and question_id in (select question_id from question_table where company_id = '" + Session["company_id"].ToString() + "') and true_false = 'True'";

            int score = (int)ccmd.ExecuteScalar();
            ccmd.CommandText = "update company_choice set written_test_marks = '" + score + "' where company_id = '" + Session["company_id"].ToString() + "' and student_id = '" + Session["student_id"] + "'";
            ccmd.ExecuteNonQuery();
            con.Close();
            Session["company_id"] = null;
             Response.Redirect("test.aspx");

            
            
        }
    }
}