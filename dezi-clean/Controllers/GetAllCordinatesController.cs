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
        public int id { get; set; }
        public string title { get; set; }

        public string color { get; set; }
        public Coordinates coordinates { get; set; }

    }
    public class Coordinates
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
    }



    public class GetAllCordinatesController : ApiController
    {
        //Student[] students = new Student[]
        List<Marker> seba = new List<Marker>();
        public List<Marker> FillData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString + "MultipleActiveResultSets=true";
            using (SqlConnection connection = new SqlConnection(connStr))
            using (SqlCommand command = new SqlCommand("SELECT TOP (1000) [id],[title],[latitude],[longitude],[aktivan], [color] FROM [dezi-me].[dbo].[Data] where aktivan = 'true'", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id;
                        var title = "";
                        string longitude = "";
                        string latitude = "";
                        string color = "";
                        //Marker seba = new Marker();
                        id = (int)reader["id"];
                        title = reader["title"].ToString();
                        longitude = reader["longitude"].ToString();
                        latitude = reader["latitude"].ToString();
                        color = reader["color"].ToString();
                        var c = System.Threading.Thread.CurrentThread.CurrentCulture;
                        var s = c.NumberFormat.CurrencyDecimalSeparator;

                        longitude = longitude.Replace(",", s);
                        longitude = longitude.Replace(".", s);
                        latitude = latitude.Replace(",", s);
                        latitude = latitude.Replace(".", s);

                        decimal longitude_pravi = Convert.ToDecimal(longitude);
                        decimal latitude_pravi = Convert.ToDecimal(latitude);

                        seba.Add(new Marker { id = id, title = title, color = color, coordinates = new Coordinates() { longitude = longitude_pravi, latitude = latitude_pravi } });

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