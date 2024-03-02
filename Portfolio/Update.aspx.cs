using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Portfolio
{
    public partial class Update : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateAboutText();
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
                            aboutMeTextBox.Text = result.ToString();
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

        protected void updateButton_Click(object sender, EventArgs e)
        {
            string aboutText = aboutMeTextBox.Text.Trim();

            try
            {
                int rowsAffected = UpdateAboutText(strcon, aboutText);
                if (rowsAffected > 0)
                {
                    Response.Redirect("~/Portfolio_main.aspx");
                }
                else
                {
                    Response.Write("<script>alert('No rows were updated.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Exception: {ex.Message}');</script>");
            }
        }

        private int UpdateAboutText(string connectionString, string aboutText)
        {
            string query = "UPDATE aboutTable SET about = @about WHERE id = 2"; // Assuming you want to update the about text for the row with id = 2

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@about", aboutText);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
