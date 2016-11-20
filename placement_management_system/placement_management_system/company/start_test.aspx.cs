using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.company
{
    public partial class start_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["company_id"] == null)
            {
                Response.Redirect("company_login.aspx", true);
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["pmsdbConnectionString"].ConnectionString;

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from company_table where company_id = '" + Session["company_id"].ToString() + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            name.Text = reader["company_name"].ToString();

            reader.Close();
            cmd.CommandText = "SELECT * from company_table where company_id = '" + Session["company_id"].ToString() + "'";
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                String start = reader["start"].ToString();
                if (start.ToLower().Equals("true"))
                {
                    start_test_div.Visible = false;
                    stop_test_div.Visible = true;
                    complete_shedule_div.Visible = false;
                }
                else
                {
                    start_test_div.Visible = true;
                    stop_test_div.Visible = false;
                    complete_shedule_div.Visible = false;
                }

            }
            else
            {
                complete_shedule_div.Visible = true;
                start_test_div.Visible = false;
                stop_test_div.Visible = false;
            }

            con.Close();
        }
        protected void start_test_click(object sender, EventArgs e)
        {

            if (htime.Value.ToString() == "" || mtime.Value.ToString() == "")
            {
                alert.InnerHtml = "<script>alert('Enter Hours and Minutes first');</script>";
            }
            else
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["pmsdbConnectionString"].ConnectionString;

                con.Open();
                SqlCommand c = new SqlCommand();
                c.Connection = con;
                c.CommandText = "Select COUNT(*) from question_table where company_id='" + Session["company_id"] + "'";
                int a = (int)c.ExecuteScalar();
                if (a != 0)
                {

                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE company_table set test_h='" + htime.Value.ToString() + "',test_m='" + mtime.Value.ToString() + "',start='true' where company_id = '" + Session["company_id"].ToString() + "'";

                cmd.ExecuteNonQuery();
                con.Close();
                start_test_div.Visible = false;
                stop_test_div.Visible = true;
                complete_shedule_div.Visible = false;
                }
                else
                {
                    alert.InnerHtml = "<script>alert('Enter Questions first');</script>";
                }
            }

            
        }

        protected void stop_test_click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["pmsdbConnectionString"].ConnectionString;

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE company_table set start='false' where company_id = '" + Session["company_id"].ToString() + "'";
          
            cmd.ExecuteNonQuery();
            con.Close();
            start_test_div.Visible = true;
            stop_test_div.Visible = false;
            complete_shedule_div.Visible = false;

       
        }
       
    }
}