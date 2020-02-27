using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace dezi_clean.Controllers
{
    public class Marker
    {
        public string id { get; set; }
        public string title { get; set; }
        public Coordinates coordinates { get; set; } 

    }
    public class Coordinates
    {
      public string latitude { get; set; }
      public string longitude { get; set; }
    }



    public class GetAllCordinatesController : ApiController
    {
        //Student[] students = new Student[]
        List<Marker> seba = new List<Marker>();
        public  List<Marker> FillData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString + "MultipleActiveResultSets=true";
            using (SqlConnection connection = new SqlConnection(connStr))
            using (SqlCommand command = new SqlCommand("SELECT TOP (1000) [id],[name],[latitude],[longitude],[aktivan]FROM [dezi-me].[dbo].[Data] where aktivan = 'true'", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = "";
                        var title = "";
                        var longitude = "";
                        var latitude = "";
                        //Marker seba = new Marker();
                        id = reader["id"].ToString();
                        title = reader["name"].ToString();
                        longitude = reader["latitude"].ToString();
                        latitude = reader["longitude"].ToString();

                        seba.Add(new Marker { id = id, title = title, coordinates = new Coordinates() { longitude = longitude, latitude = latitude } });

                    }

                }
                connection.Close();
            }
          return seba;
        }


        [HttpGet]
        [Route("api/GetLocation/Location")]
        public HttpResponseMessage GetAllMessages(List<Marker> data)
        {
            data = FillData();
            var jsonmsg = JsonConvert.SerializeObject(data);
            var res = Request.CreateResponse(HttpStatusCode.OK);
            res.Content = new StringContent(jsonmsg, System.Text.Encoding.UTF8, "application/json");
            return res;
        }
    }
}