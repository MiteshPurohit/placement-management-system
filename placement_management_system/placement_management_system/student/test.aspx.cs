using System;
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
            Session["student_id"] = '1';
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
            con.Open();
            SqlCommand c = new SqlCommand();
            c.Connection = con;
            c.CommandText = "SELECT * from student_table where student_id = '" + Session["student_id"].ToString() + "'";
            SqlDataReader r = c.ExecuteReader();
            r.Read();
            name.Text = r["full_name"].ToString();
            con.Close();
            questions_div.Visible = false;
            start_test_div.Visible = true;
            complete_test_div.Style.Add("display", "none");
        }

        protected void start_test_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
            con.Open();
            SqlCommand c = new SqlCommand();
            c.Connection = con;
            c.CommandText = "SELECT * from schedule where company_id = '" + Request.QueryString["id"] + "'";
            SqlDataReader r = c.ExecuteReader();
            r.Read();
            questions_div.Visible = true;
            start_test_div.Visible = false;
            complete_test_div.Style.Add("display", "none");
            _script.InnerHtml = @"<script> var timerVar = setInterval(countTimer, 1000);
var totalSeconds = " + Int32.Parse(r["test_h"].ToString()) * 60 * 60 + Int32.Parse(r["test_m"].ToString()) * 60 + @";
function countTimer() {
--totalSeconds;
if(totalSeconds==0){
clearInterval(timerVar);
$('#complete_test_div').css('display', 'block');
$('#questions_div').css('display', 'none');
$('#submit_btn').click();
}
var hour = Math.floor(totalSeconds /3600);
var minute = Math.floor((totalSeconds - hour*3600)/60);
var seconds = totalSeconds - (hour*3600 + minute*60);

document.getElementById('timer').innerHTML = hour + ':' + minute + ':' + seconds;
}
</Script>";
        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {

        }
    }
}