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
    public partial class experience : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            GVbind();

        }



        private void GVbind()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select type,skillName,skillImage,skillLevel from Experience_table", con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
                con.Close();
            }

        }

        protected void includeButton_Click(object sender, EventArgs e)
        {
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
                            SqlCommand cmd = new SqlCommand("INSERT INTO Experience_table([type],[skillName],[skillImage],[skillLevel]) VALUES ('" + DropDownList1.SelectedItem.Text + "','" + SkillNameTextBox.Text + "','" + path2 + "','" + DropDownList2.SelectedItem.Text + "')", con);

                            int t = cmd.ExecuteNonQuery();
                            if (t > 0)
                            {
                                Response.Write("<script>alert('File has been uploaded successfully !')</script>");

                                GVbind();

                            }
                        }

                        SkillNameTextBox.Text = string.Empty;
                        DropDownList1.ClearSelection();
                        DropDownList2.ClearSelection();

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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "upd")
            {
                Response.Redirect("~/UpdateExperience.aspx?name=" + e.CommandArgument.ToString().Trim() + "");
            }
            else if (e.CommandName == "del")
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE FROM Experience_table where skillName=@name", con);
                    cmd.Parameters.AddWithValue("@name", e.CommandArgument.ToString().Trim());
                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Redirect("~/experience.aspx");
                }
                catch (Exception ex)
                {
                    LabelMessage.Text = "the file could not be deleted.The following error occured:" + ex.Message;
                }
            }
        }
    }
}