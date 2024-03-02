using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class UpdateExperience : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = Request.QueryString["name"].Trim();
                if (!string.IsNullOrEmpty(name))
                {
                    PopulateCourseDetails(name);
                }
                else
                {
                    // Handle error: no ID provided
                }
            }

        }
        private void PopulateCourseDetails(string name)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "SELECT * FROM Experience_table WHERE skillName='" + name + "'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                typeDropDownList.SelectedValue = sdr.GetValue(0).ToString();
                                SkillNameTextBox.Text = sdr.GetValue(1).ToString();
                                imagePathTextBox.Text = sdr.GetValue(2).ToString();
                                levelDropDownList.SelectedValue = sdr.GetValue(3).ToString();
                                
                                
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
            string name = SkillNameTextBox.Text.Trim();
            if (FileUpload1.HasFiles)
            {
                try
                {
                    string extension = Path.GetExtension(FileUpload1.FileName);
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                    {


                        string fname = Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.SaveAs(Server.MapPath("Experience/") + fname);
                        string path2 = "Experience/" + fname;
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            con.Open();
                            string query = "UPDATE Experience_table SET type=@type,skillName=@name,skillImage=@image,skillLevel=@skillLevel WHERE skillName=@name";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@name", name);
                                cmd.Parameters.AddWithValue("@type",typeDropDownList.SelectedValue);
                                cmd.Parameters.AddWithValue("@image", path2);
                                cmd.Parameters.AddWithValue("@skillLevel", levelDropDownList.SelectedValue);
                                


                                int t = cmd.ExecuteNonQuery();
                                if (t > 0)
                                {
                                    Response.Write("<script>alert('File has been updated successfully !')</script>");
                                    Response.Redirect("~/experience.aspx");
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