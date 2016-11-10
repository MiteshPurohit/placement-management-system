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
            c.CommandText = "SELECT * from company_table where company_id = '" + Session["student_id"].ToString() + "'";
            SqlDataReader r = c.ExecuteReader();
            r.Read();
            questions_div.Visible = true;
            start_test_div.Visible = false;
            //complete_test_div.Style.Add("display", "none");
            _script.InnerHtml = @"<script> 
var totalSeconds = 0;
function abcd(){
if(readCookie('time" + Session["student_id"].ToString() + Session["company_id"].ToString() + @"')!=null){
//alert(totalSeconds+'###0');
    totalSeconds = readCookie('time" + Session["student_id"].ToString() + Session["company_id"].ToString() + @"');
//alert(totalSeconds+'###1');
}
else{
//alert(totalSeconds+'!!!0');
                                totalSeconds = " + Int32.Parse(r["test_h"].ToString()) * 60 * 60 + Int32.Parse(r["test_m"].ToString()) * 60 + @";
//alert(totalSeconds+'!!!1');
}

//alert(totalSeconds+'0');
var timerVar = setInterval(countTimer, 1000);
//alert(totalSeconds+'1');
}


                                function countTimer() {
//alert(totalSeconds+'2');
                                totalSeconds -= 1;
//alert(totalSeconds+'3');
createCookie('time" + Session["student_id"].ToString() + Session["company_id"].ToString() + @"',totalSeconds,1);
//alert(totalSeconds+'4');
                                if(totalSeconds==0){
                                clearInterval(timerVar);
createCookie('time" + Session["student_id"].ToString() + Session["company_id"].ToString() + @"',totalSeconds,-1);
//alert(totalSeconds+'5');
                                $('#complete_test_div').css('display', 'block');
                                $('#questions_div').css('display', 'none');
                                $('#submit_btn').click();

                                }
//alert(totalSeconds+'6');
                                var hour = parseInt(totalSeconds/3600);
//alert(totalSeconds+'7');
                                var minute = parseInt((totalSeconds/60));
//alert(totalSeconds+'8');
                                var seconds = totalSeconds - (hour*3600 + minute*60);
//alert(totalSeconds+'9');

                                document.getElementById('timer').innerHTML = totalSeconds + ' '+hour + ':' + minute + ':' + seconds;
//alert(totalSeconds+'10');
                                }
$(document).ready(function(){
abcd();
});

                                </Script>";
        }
       
        protected void submit_btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
            con.Open();
            SqlCommand c = new SqlCommand();
            c.Connection = con;
            c.CommandText = "update company_choice set written_test_given = 'true' where student_id = '" + Session["student_id"].ToString() + "' and company_id = '" + Request.QueryString["id"] + "'";
            c.ExecuteNonQuery();
            List<string> listkeys = new List<string>();
            foreach (string key in Request.Form.AllKeys)
            {

                listkeys.Add(key);
                
            }
            foreach (var key in listkeys )
            {
                string ans = (string)Request.Form[key];
                
                Console.Write(key);
                SqlDataReader r;
                try
                {
                    c.CommandText = "select * from question_table where question_id = '" + key + "'";
                   r = c.ExecuteReader();
                    r.Read();
                
                
                if (r["choice_ans"].ToString().ToLower().Equals(ans.ToLower()))
                {
                    c.CommandText = "insert into student_test_data (question_id, student_id, mcq_choice, true_false) values('" + key + "', '" + Session["student_id"] + "','" + ans + "',true)";
                    c.ExecuteNonQuery();
                }
                else
                {
                    c.CommandText = "insert into student_test_data (question_id, student_id, mcq_choice, true_false) values('" + key + "', '" + Session["student_id"] + "','" + ans + "',false)";
                    c.ExecuteNonQuery();
                }
                r.Close();
                    }
                catch (Exception eee)
                {
                    name.Text = key;
                }

            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
           
            questions_div.Visible = false;
            start_test_div.Visible = false;
           // complete_test_div.Style.Add("display", "block");
            test_given_div.Visible = true;
        }

      
    }
}