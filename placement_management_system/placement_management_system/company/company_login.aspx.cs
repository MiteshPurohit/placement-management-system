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
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\v11.0\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
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
                    Response.Redirect("company_home.aspx");
                }
                else
                {
                    //incorrect password
                }

            }
            else
            {
                //incorrect username
            }
            con.Close();
        }
    }
}