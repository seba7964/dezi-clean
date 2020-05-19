using dezi_clean.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dezi_clean
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlaceHolder hideNavigationItems = this.Page.Master.FindControl("hideNavigationItems") as PlaceHolder;

            if(hideNavigationItems == null)
            {

            }
            else
            {
                hideNavigationItems.Visible = false;
            }


            if (Session["username"] == null)
            {
                Response.Redirect("Default.aspx");
            }


            ArrayList values = new ArrayList();
            values = GetDataFromDB.GetDataForBind("IS NOT NULL");


            myCustomRepeater.DataSource = values;
            myCustomRepeater.DataBind();
        }

        protected void deactivatePost(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            updateValueData(btn.CommandArgument);
            Response.Redirect("Admin.aspx");

            

        }

        protected void updateValueData (string id)
        {

            string sqlquery = String.Format("UPDATE dbo.Data SET aktivan = 'false' where ID = {0}", id);
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString + "MultipleActiveResultSets=true";
            using (SqlConnection connection = new SqlConnection(connStr))
            using (SqlCommand command = new SqlCommand(sqlquery, connection))
            {
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }

        }
    }
}