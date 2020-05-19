using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace dezi_clean.Controllers
{
    public class GetDataFromDB
    {
        public class Data
        {
            public string id { get; set; }
            public string title { get; set; }
            public string name { get; set; }
            public string lastname { get; set; }
            public string problemdescription { get; set; }
            public string longitude { get; set; }
            public string latitude { get; set; }
            public string imagepath { get; set; }
            public string date { get; set; }

            public Data(string id, string title, string name, string lastname, string problemdescription, string longitude, string latitude, string imagepath, string date)
            {
                this.id = id;
                this.title = title;
                this.name = name;
                this.lastname = lastname;
                this.problemdescription = problemdescription;
                this.longitude = longitude;
                this.latitude = latitude;
                this.imagepath = imagepath;
                this.date = date;
            }
        }
        public static ArrayList GetDataForBind(string kategorija)
        {

            ArrayList values = new ArrayList();
            string sqlquery = String.Format("SELECT TOP (1000) [id],[title],[name],[lastname],[problemdescription],[latitude],[longitude],[imagepath],[date],[category],[color],[aktivan] FROM [dezi-me].[dbo].[Data] where aktivan = 'true' and category {0} order by id desc", kategorija);
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString + "MultipleActiveResultSets=true";
            using (SqlConnection connection = new SqlConnection(connStr))
            using (SqlCommand command = new SqlCommand(sqlquery, connection))
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
                        var date = reader["date"].ToString();
                        values.Add(new Data(id, title, name, lastname, problemdescription, longitude, latitude, imagepath, date));
                    }
                }
                connection.Close();
            }

            return values;
        }
    }
}