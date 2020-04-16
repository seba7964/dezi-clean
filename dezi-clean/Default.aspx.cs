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

    public partial class _Default : Page
    {

        public class Data
        {
            private string id;
            private string title;
            private string name;
            private string lastname;
            private string problemdescription;
            private string longitude;
            private string latitude;
            private string imagepath;

            public Data(string id, string title, string name, string lastname, string problemdescription, string longitude, string latitude, string imagepath)
            {
                this.id = id;
                this.title = title;
                this.name = name;
                this.lastname = lastname;
                this.problemdescription = problemdescription;
                this.longitude = longitude;
                this.latitude = latitude;
                this.imagepath = imagepath;
               
            }
            public string Id
            {
                get
                {
                    return id;
                }
            }
            public string Title
            {
                get
                {
                    return title;
                }
            }
            public string Name
            {
                get
                {
                    return name;
                }
            }
            public string LastName
            {
                get
                {
                    return lastname;
                }
            }

            public string Problemdescription
            {
                get
                {
                    return problemdescription;
                }
            }
            public string Longitude
            {
                get
                {
                    return longitude;
                }
            }
            public string Latitude
            {
                get
                {
                    return latitude;
                }
            }

            public string Imagepath
            {
                get
                {
                    return imagepath;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            ArrayList values = new ArrayList();
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString + "MultipleActiveResultSets=true";
            using (SqlConnection connection = new SqlConnection(connStr))
            using (SqlCommand command = new SqlCommand("SELECT TOP (50) [id],[title],[name],[lastname],[problemdescription],[latitude],[longitude],[imagepath],[aktivan] FROM [dezi-me].[dbo].[Data] where aktivan = 'true' order by id desc", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var id = reader["id"].ToString();
                        var title = reader["title"].ToString();
                        var name = reader["name"].ToString();
                        var lastname = reader["lastname"].ToString();
                        var problemdescription = reader["problemdescription"].ToString();
                        var latitude = reader["latitude"].ToString();
                        var longitude = reader["longitude"].ToString();
                        var imagepath = reader["imagepath"].ToString();
                        values.Add(new Data(id, title, name, lastname, problemdescription, longitude, latitude, imagepath));
                    }

                    myCustomRepeater.DataSource = values;
                    myCustomRepeater.DataBind();
                }
                connection.Close();
            }
        }
    }
}
