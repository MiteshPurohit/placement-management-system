using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system
{
    public partial class company_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login_btn_click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["pmsdbConnectionString"].ConnectionString;

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from company_table where email = '" + company_id.Text.ToString() + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (((String)reader["password"].ToString()).Equals((String)pass.Text.ToString()))
                {
                    Session["company_id"] = reader["company_id"];
                    Response.Redirect("dashboard.aspx",true);
                }
                else
                {
                    alert.InnerHtml = "<script>alert('Invalid Password');</script>";
                }

            }
            else
            {
                alert.InnerHtml = "<script>alert('Invalid Username');</script>";
            }
            con.Close();
        }
    }
}