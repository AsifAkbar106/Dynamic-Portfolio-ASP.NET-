using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Portfolio_main : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateAboutText();
            BindProjects();
            BindExperience();

        }
        private void BindExperience()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    // Query to select frontend experience
                    string frontendQuery = "SELECT skillName, skillImage,skillLevel FROM Experience_table WHERE type = @frontendType";
                    // Query to select backend experience
                    string backendQuery = "SELECT skillName, skillImage,skillLevel FROM Experience_table WHERE type = @backendType";

                    using (SqlCommand frontendCmd = new SqlCommand(frontendQuery, con))
                    using (SqlCommand backendCmd = new SqlCommand(backendQuery, con))
                    {
                        // Parameters for frontend and backend types
                        frontendCmd.Parameters.AddWithValue("@frontendType", "Frontend");
                        backendCmd.Parameters.AddWithValue("@backendType", "Backend");

                        // Execute frontend query
                        using (SqlDataReader frontendReader = frontendCmd.ExecuteReader())
                        {
                            while (frontendReader.Read())
                            {
                                string skillName = frontendReader["skillName"].ToString();
                                string skillImage = frontendReader["skillImage"].ToString();
                                string skillLevel = frontendReader["skillLevel"].ToString();

                                // Create HTML for the skill
                                string skillHtml = $@"
                            <div class='article'>
                                <img src='{skillImage}' alt='{skillName}' class='icon' />
                                <h3>{skillName}</h3>
                                <p class='experience-page'>{skillLevel}</p>
                            </div>";

                                // Add the skill HTML to the frontend experience container
                                frontendExperienceContainer.Controls.Add(new LiteralControl(skillHtml));
                            }
                        }

                        // Execute backend query
                        using (SqlDataReader backendReader = backendCmd.ExecuteReader())
                        {
                            while (backendReader.Read())
                            {
                                string skillName = backendReader["skillName"].ToString();
                                string skillImage = backendReader["skillImage"].ToString();
                                string skillLevel= backendReader["skillLevel"].ToString() ;

                                // Create HTML for the skill
                                string skillHtml = $@"
                            <div class='article'>
                                <img src='{skillImage}' alt='{skillName}' class='icon' />
                                <h3>{skillName}</h3>
                                <p class='experience-page'>{skillLevel}</p>
                            </div>";

                                // Add the skill HTML to the backend experience container
                                backendExperienceContainer.Controls.Add(new LiteralControl(skillHtml));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle error
                Response.Write($"<script> alert('Exception: {ex.Message}')</script>");
            }
        }






        private void BindProjects()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "SELECT project_name, project_pic, github, livedemo FROM project_table";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string projectName = reader["project_name"].ToString();
                            string projectPic = reader["project_pic"].ToString();
                            string githubLink = reader["github"].ToString();
                            string liveDemoLink = reader["livedemo"].ToString();

                            // Create a new panel for each project
                            Panel projectPanel = new Panel();
                            projectPanel.CssClass = "details-container color-container";

                            // Create an image control for project picture
                            Image projectImage = new Image();
                            projectImage.ImageUrl = projectPic;
                            projectImage.AlternateText = projectName;
                            projectImage.CssClass = "project-img";

                            // Create a label for project name
                            Label projectNameLabel = new Label();
                            projectNameLabel.Text = $"<h2 class='experience-sub-title project-title'>{projectName}</h2>";

                            // Create buttons for GitHub and Live Demo links
                            Button githubButton = new Button();
                            githubButton.CssClass = "btn btn-color-2 project-btn";
                            githubButton.Text = "GitHub";
                            githubButton.OnClientClick = $"window.open('{githubLink}')";

                            Button liveDemoButton = new Button();
                            liveDemoButton.CssClass = "btn btn-color-2 project-btn";
                            liveDemoButton.Text = "Demo Video";
                            liveDemoButton.OnClientClick = $"window.open('{liveDemoLink}')";

                            // Add controls to the project panel
                            projectPanel.Controls.Add(projectImage);
                            projectPanel.Controls.Add(projectNameLabel);
                            projectPanel.Controls.Add(githubButton);
                            projectPanel.Controls.Add(liveDemoButton);

                            // Add the project panel to the projects container
                            projectsContainer.Controls.Add(projectPanel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle error
                Response.Write($"<script> alert('Exception: {ex.Message}')</script>");
            }
        }



        private void PopulateAboutText()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "SELECT about FROM aboutTable WHERE id = 2"; // Assuming you want to update the about text for the row with id = 2
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            AboutMeLabel.Text = result.ToString();
                        }
                        else
                        {
                            // Handle error: no row found with the provided ID
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle error
                Response.Write($"<script> alert('Exception: {ex.Message}')</script>");
            }

        }

        protected void AdminButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/adminPage.aspx");

        }
    }
}