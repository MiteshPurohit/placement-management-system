using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system.company
{
    public partial class view_students : System.Web.UI.Page
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


        protected void DownloadFile(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select refrance_documents from student_table where student_id='" + (sender as LinkButton).CommandArgument + "'";
                SqlDataReader obj = cmd.ExecuteReader();
                byte[] bytes = (byte[])obj.GetValue(0);
                con.Close();
                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=ref_doc.zip");
                Response.BinaryWrite(bytes);
                Response.End(); 
            }
            catch (Exception eeee)
            {
                MemoryStream ms = new MemoryStream();
                TextWriter tw = new StreamWriter(ms);
                tw.WriteLine("Student has not uploaded refrance documents");
                tw.Flush();
                byte[] bytes = ms.ToArray();
                ms.Close();
                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=file.txt");
                Response.BinaryWrite(bytes);
                Response.End(); 
            }
             
        }
    }
}