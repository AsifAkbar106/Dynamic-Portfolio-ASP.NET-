using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class UpdateProject : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"].Trim();
                if (!string.IsNullOrEmpty(id))
                {
                    PopulateCourseDetails(id);
                }
                else
                {
                    // Handle error: no ID provided
                }
            }
            

        }

        private void PopulateCourseDetails(string id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "SELECT * FROM project_table WHERE id=" + id + "";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                idTextBox.Text = sdr.GetValue(0).ToString();
                                ProjectNameTextBox.Text = sdr.GetValue(1).ToString();
                                FileUploadTextBox.Text = sdr.GetValue(2).ToString();
                                gitHubTextBox.Text = sdr.GetValue(3).ToString();
                                demoLinkTextBox.Text = sdr.GetValue(4).ToString();
                            }
                            else
                            {
                                // Handle error: no course found with the provided ID
                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                LabelMessage.Text = "the file could not be uploaded.The following error occured:" + ex.Message;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            string id=idTextBox.Text.Trim();
            if (FileUpload1.HasFiles)
            {
                try
                {
                    string extension = Path.GetExtension(FileUpload1.FileName);
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                    {


                        string fname = Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.SaveAs(Server.MapPath("Images/") + fname);
                        string path2 = "Images/" + fname;
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            con.Open();
                            string query = "UPDATE project_table SET project_name=@name,project_pic=@pic,github=@github,livedemo=@livedemo WHERE id=@id";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.Parameters.AddWithValue("@name", ProjectNameTextBox.Text.Trim());
                                cmd.Parameters.AddWithValue("@pic", path2);
                                cmd.Parameters.AddWithValue("@github", gitHubTextBox.Text.Trim());
                                cmd.Parameters.AddWithValue("@livedemo", demoLinkTextBox.Text.Trim());


                                int t = cmd.ExecuteNonQuery();
                                if (t > 0)
                                {
                                    Response.Write("<script>alert('File has been updated successfully !')</script>");
                                    Response.Redirect("~/projects.aspx");
                                }

                            }
                            
                            

                        }
                    }
                    else
                    {
                        LabelMessage.Text = "Only jpg,jpeg,png files are accepted!";
                        LabelMessage.ForeColor = System.Drawing.Color.Red;
                    }

                }
                catch (Exception ex)
                {
                    LabelMessage.Text = "the file could not be uploaded.The following error occured:" + ex.Message;
                }
            }
        }
    }
}