using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.company
{
    public partial class add_question : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["company_id"] == null)
            {
                Response.Redirect("company_login.aspx", true);
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from company_table where company_id = '" + Session["company_id"].ToString() + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            name.Text = reader["company_name"].ToString();
            con.Close();
        }
      

        protected void submit_Click(object sender, EventArgs e)
        {
           
            String id = Session["company_id"].ToString();
            String q = question.Value.ToString();
            String a = opta.Value.ToString();
            String b = optb.Value.ToString();
            String c = optc.Value.ToString();
            String d = optd.Value.ToString();
            String answer = ans.Value.ToString();
            

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30";
            con.Open();
            SqlCommand ccmd = new SqlCommand();
            ccmd.Connection = con;
            ccmd.CommandText = "INSERT INTO question_table (question,option_a,option_b,option_c,option_d,choice_ans,company_id) values('" + q + "','" + a + "','" + b + "','" + c + "','" + d + "','" + answer + "','" + id + "')";
            try
            {
                ccmd.ExecuteNonQuery();
            }
            catch (Exception eee)
            {
                Response.Redirect("../error.aspx", true);
            }
            
            alert.InnerHtml = "<script>alert('Question added');</script>";
            con.Close();
            question.Value = "";
            opta.Value = "";
            optb.Value = "";
            optc.Value = "";
            optd.Value = "";
            ans.SelectedIndex = 0;
           
        }
    }
}