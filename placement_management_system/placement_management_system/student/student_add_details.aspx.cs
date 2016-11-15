using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.student
{
    public partial class student_add_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["student_id"] == null)
            {
                Response.Redirect("student_login.aspx", true);
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from student_table where student_id = '" + Session["student_id"].ToString() + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            name.Text = reader["full_name"].ToString();
            fname.Text = reader["full_name"].ToString();
            branch.SelectedValue = reader["branch"].ToString();
            cpi.Text = reader["cpi"].ToString();
            birthdate.Text = reader["dob"].ToString();
            skills.Text = reader["skills"].ToString();
            email.Text = reader["email_id"].ToString();
            achievement.Text = reader["achievement"].ToString();
            mobileno.Text = reader["mobile_no"].ToString();
            fname.Enabled = false;
            branch.Enabled = false;
            cpi.Enabled = false;
            con.Close();
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                String id = Session["student_id"].ToString();
                var fileName = "";
                var fileMime = "";
                byte[] fileContent = null;
                var uploadedFile = Request.Files[0];
                fileName = Path.GetFileName(uploadedFile.FileName);
                if (fileName != String.Empty)
                {
                    fileMime = uploadedFile.ContentType;
                    var fileStream = uploadedFile.InputStream;
                    var fileLength = uploadedFile.ContentLength;

                    //chk file size and file type

                    fileContent = new byte[fileLength];
                    fileStream.Read(fileContent, 0, fileLength);
                }
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE student_table set mobile_no='" + mobileno.Text.ToString() + "', email_id = '" + email.Text.ToString() + "', skills = '" + skills.Text.ToString() + "', achievement = '" + achievement.Text.ToString() + "', refrance_documents = @file where student_id = '" + id + "'";
                cmd.Parameters.AddWithValue("@file", fileContent);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}