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
    public partial class projects : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clearfn();
                GVbind();
            }
        }

        protected void GVbind()
        {
            using(SqlConnection con=new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from project_table",con);

                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFiles)
            {
                try
                {
                    string extension=Path.GetExtension(FileUpload1.FileName);
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png") {
                        
                        
                        string fname = Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.SaveAs(Server.MapPath("Images/") + fname);
                        string path2 = "Images/" + fname;
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("INSERT INTO project_table([id],[project_name],[project_pic],[github],[livedemo]) values ('" + idTextBox.Text + "','" + ProjectNameTextBox.Text + "','" + path2 + "','" + gitHubTextBox.Text + "','" + demoLinkTextBox.Text + "')", con);

                            int t = cmd.ExecuteNonQuery();
                            if (t > 0)
                            {
                                Response.Write("<script>alert('File has been uploaded successfully !')</script>");
                                clearfn();
                                GVbind();
                            }
                            
                        }
                    }
                    else
                    {
                        LabelMessage.Text = "Only jpg,jpeg,png files are accepted!";
                        LabelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                   
                }
                catch(Exception ex)
                {
                    LabelMessage.Text="the file could not be uploaded.The following error occured:"+ex.Message;
                }
            }
        }
        public void clearfn()
        {
            idTextBox.Text = string.Empty;
            ProjectNameTextBox.Text = string.Empty;
            demoLinkTextBox.Text = string.Empty;
            gitHubTextBox.Text = string.Empty;

            
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "upd")
            {
                Response.Redirect("~/UpdateProject.aspx?id="+ e.CommandArgument.ToString().Trim() +"");
            }
            else if(e.CommandName == "del")
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if(con.State==ConnectionState.Closed) {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE FROM project_table where id=@id",con);
                    cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Redirect("~/projects.aspx");
                }
                catch (Exception ex)
                {
                    LabelMessage.Text = "the file could not be deleted.The following error occured:" + ex.Message;
                }
            }
        }
    }   
}