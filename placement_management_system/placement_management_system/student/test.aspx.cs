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
    public partial class test : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["student_id"] == null)
            {
                Response.Redirect("student_login.aspx", true);
            }

            if (string.IsNullOrEmpty(Session["company_id"] as string))
            {
                Response.Redirect("select_company_for_test.aspx", true);
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
            r.Close();

            c.CommandText = "SELECT * from company_choice where student_id = '" + Session["student_id"].ToString() + "' and company_id = '" + Session["company_id"].ToString() + "'";
            r = c.ExecuteReader();
            r.Read();
            if (r["written_test_given"].ToString().ToLower().Equals("false"))
            {
                questions_div.Visible = false;
                start_test_div.Visible = true;
               // complete_test_div.Style.Add("display", "none");
                test_given_div.Visible = false;
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select COUNT(*) from student_test_data where student_id = '" + Session["student_id"] + "' and question_id in (select question_id from question_table where company_id = '" + Session["company_id"].ToString() + "') and true_false = 'True'";
               
               score.InnerHtml = cmd.ExecuteScalar().ToString();
                questions_div.Visible = false;
                start_test_div.Visible = false;
               // complete_test_div.Style.Add("display", "none");
                test_given_div.Visible = true;
            }
            con.Close();
            
        }

        protected void start_test_Click(object sender, EventArgs e)
        {
            company_id.Value = Request.QueryString["id"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
            con.Open();
            SqlCommand c = new SqlCommand();
            c.Connection = con;
            c.CommandText = "SELECT * from company_table where company_id = '" + Session["company_id"].ToString() + "'";
            SqlDataReader r = c.ExecuteReader();
            r.Read();
            questions_div.Visible = true;
            start_test_div.Visible = false;
            //complete_test_div.Style.Add("display", "none");
            _script.InnerHtml = @"<script> 
var totalSeconds = 0;
function abcd(){
if(readCookie('time" + Session["student_id"].ToString() + Session["company_id"].ToString() + @"')!=null){
    totalSeconds = readCookie('time" + Session["student_id"].ToString() + Session["company_id"].ToString() + @"');
}
else{
var hour_s = "+Int32.Parse(r["test_h"].ToString()) * 60 * 60+@";
var min_s = "+Int32.Parse(r["test_m"].ToString()) * 60 + @";
totalSeconds = hour_s + min_s;
}
var timerVar = setInterval(countTimer, 1000);
}
                                function countTimer() {
                               totalSeconds -= 1;
createCookie('time" + Session["student_id"].ToString() + Session["company_id"].ToString() + @"',totalSeconds,1);
                                if(totalSeconds==0){
                                clearInterval(timerVar);
createCookie('time" + Session["student_id"].ToString() + Session["company_id"].ToString() + @"',totalSeconds,-1);
                                $('#complete_test_div').css('display', 'block');
                                $('#questions_div').css('display', 'none');
                                $('#submit_btn').click();

                                }

                                var hour = parseInt(totalSeconds/3600);
                                var minute = parseInt((totalSeconds/60)) - hour*60;
                                var seconds = totalSeconds - (hour*3600 + minute*60);
                                document.getElementById('timer').innerHTML = 'Time Left: '+hour + ':' + minute + ':' + seconds;
                                }
$(document).ready(function(){
abcd();
});

                                </Script>";
            Session["start_test"] = "true";
        }
       
       
      
    }
}