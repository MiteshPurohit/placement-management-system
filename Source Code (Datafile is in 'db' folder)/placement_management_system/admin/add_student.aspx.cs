using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace placement_management_system
{
    public partial class admin_home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin_id"] == null)
            {
                Response.Redirect("admin_login.aspx", true);
            }
            fname.Text = "";
            cpi.Text = "";
            birthdate.Text = "";
            password.Text = "";
            collage_id.Text = "";
            branch.SelectedIndex = 0;
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            var uploadedFile = Request.Files[0];
            var fileName = "";
            var fileMime = "";
                fileName = Path.GetFileName(uploadedFile.FileName);
                if (fileName != String.Empty)
                {
                    try
                    {
                        fileMime = uploadedFile.ContentType;
                        var fileStream = uploadedFile.InputStream;
                        var file = File.Create(AppDomain.CurrentDomain.BaseDirectory + "student_data.xlsx");
                        fileStream.Seek(0, SeekOrigin.Begin);
                        fileStream.CopyTo(file);
                        file.Close();
                        fileStream.Close();
                        String constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", AppDomain.CurrentDomain.BaseDirectory + "student_data.xlsx");
                        OleDbConnection Econ = new OleDbConnection(constr);

                        string exlqry = string.Format("Select [full_name],[dob],[cpi],[collage_id],[branch],[password] FROM [{0}]", "Sheet1$");

                        OleDbCommand Ecom = new OleDbCommand(exlqry, Econ);
                        Econ.Open();
                        DataSet ds = new DataSet();
                        OleDbDataAdapter oda = new OleDbDataAdapter(exlqry, Econ);
                        Econ.Close();

                        oda.Fill(ds);
                        DataTable Exceldt = ds.Tables[0];

                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
                        con.Open();

                        SqlBulkCopy objbulk = new SqlBulkCopy(con);
                        //assigning Destination table name    
                        objbulk.DestinationTableName = "student_table";
                        //Mapping Table column    
                        objbulk.ColumnMappings.Add("full_name", "full_name");
                        objbulk.ColumnMappings.Add("dob", "dob");
                        objbulk.ColumnMappings.Add("cpi", "cpi");
                        objbulk.ColumnMappings.Add("collage_id", "collage_id");
                        objbulk.ColumnMappings.Add("branch", "branch");
                        objbulk.ColumnMappings.Add("password", "password");
                        //inserting Datatable Records to DataBase    

                        objbulk.WriteToServer(Exceldt);
                        con.Close();
                        script.InnerHtml = @"<script>
                                            alert('students updated');
                                        </script>";
                    }
                    catch (Exception eee)
                    {
                        script.InnerHtml = @"<script>
                                            alert('Invalid input file. try again :| or one  of the  student already exists');
                                        </script>";
                    }

                }
                else
                {
                    script.InnerHtml = @"<script>
                                            alert('Invalid input file. try again :|');
                                        </script>";
                }
                
        }

        protected void manual_insert_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Sanket Bhimani\Source\Repos\placement-management-system\placement_management_system\placement_management_system\db\pmsdb.mdf';Integrated Security=True;Connect Timeout=30";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into student_table (collage_id, password, branch, dob, cpi, full_name) values('" + collage_id.Text + "', '" + password.Text + "', '" + branch.SelectedValue + "', '" + birthdate.Text + "', '" + cpi.Text + "', '" + fname.Text + "')";

                cmd.ExecuteNonQuery();
                con.Close();
                script.InnerHtml = @"<script>
                                            alert('students updated');
                                        </script>";
            }
            catch (Exception eee)
            {
                script.InnerHtml = @"<script>
                                            alert('Invalid input, try again :| possibly you are entering same collage id again');
                                        </script>";
            }
        }
    }
}