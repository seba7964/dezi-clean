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
        public List<Coordinates> coordinates { get; set; } 
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

          seba.Add(new Marker { id = 1, title = "Naslov1",
              coordinates = new List<Coordinates>
          {
              new Coordinates()
              {
                  longitude = "4444444",
                  latitude = "4444444"
              }
          },
          });
            seba.Add(new Marker
            {
                id = 2,
                title = "Naslov2",
                coordinates = new List<Coordinates>
          {
              new Coordinates()
              {
                  longitude = "5555555",
                  latitude = "5555555"
              }
          },
            });
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