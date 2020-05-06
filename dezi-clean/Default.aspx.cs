using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dezi_clean.Controllers;


namespace dezi_clean
{

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            PlaceHolder objPlaceHolder = this.Page.Master.FindControl("mojplaceholder") as PlaceHolder;
            PlaceHolder hideFooter = this.Page.Master.FindControl("hideFooter") as PlaceHolder;
            if (objPlaceHolder == null)
            {

            }
            else
            {
                objPlaceHolder.Visible = false;
                
            }

            if(hideFooter == null)
            {

            } else
            {
                hideFooter.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string sqlquery = "SELECT COUNT (1) FROM[dezi-me].[dbo].[Users] where username = @username and password = @password";
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString + "MultipleActiveResultSets=true";
            using (SqlConnection connection = new SqlConnection(connStr))
            using (SqlCommand command = new SqlCommand(sqlquery, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                command.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 1)
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    lblErrorMessage.Visible = true;
                }
                connection.Close();
            }
        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dezinfekcija.aspx");
        }

    }
}
