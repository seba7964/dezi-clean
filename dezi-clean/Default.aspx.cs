using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace dezi_clean
{

    public partial class _Default : Page
    {
        public string test { get; set; }

        public class EventSeba
        {
            public string id { get; set; }
            public string name;
            public string lastname;
            public string longitude;
            public string latitude;
            public string imagepath;


        }
        protected void Page_Load(object sender, EventArgs e)
        {
           // test = "seba";
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString + "MultipleActiveResultSets=true";
            using (SqlConnection connection = new SqlConnection(connStr))
            using (SqlCommand command = new SqlCommand("SELECT TOP (1000) [id],[name],[lastname],[latitude],[longitude],[imagepath] FROM [dezi-me].[dbo].[Podaci]", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        
                        EventSeba EventSeba = new EventSeba();
                        EventSeba.id = reader["id"].ToString();
                        EventSeba.name = reader["name"].ToString();
                        EventSeba.lastname = reader["lastname"].ToString();
                        EventSeba.longitude = reader["latitude"].ToString();
                        EventSeba.latitude = reader["longitude"].ToString();
                        EventSeba.imagepath = reader["imagepath"].ToString();
                        test = reader["name"].ToString();
                    }

                }
                connection.Close();
            }
        }
    }
}
