using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["UserInfo"];

            if (cookie != null)
            {
                Response.Redirect("~/about_me_dash.aspx");
            }
            
            
            

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from Admin where Username=@username and Password=@password ", con);

                cmd.Parameters.AddWithValue("@username",username.Value);
                cmd.Parameters.AddWithValue ("@password",password.Value);

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    if (CheckBox1.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("UserInfo");
                        cookie["name"] = username.Value;
                        cookie["password"] = password.Value;

                        cookie.Expires = DateTime.Now.AddHours(1);

                        Response.Cookies.Add(cookie);


                    }
                 
                    Response.Redirect("~/about_me_dash.aspx");

                }
                else
                {
                    Response.Write("<script> alert('Wrong Username or Password')</script>"); 
                }



                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Exception:" + ex.Message + "')</script>");
            }

        }
    }
}