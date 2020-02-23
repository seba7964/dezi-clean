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
    public class FileUploadingController : ApiController
    {
        [HttpPost]
        [Route("api/FileUploading/UploadFile")]
        public async Task<string> UploadFile()
        {

            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/slike");

            var provider =
                new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                {
                    foreach (var file in provider.FileData)
                    {


                        var name = file.Headers.ContentDisposition.FileName;
                        //Remove dobule quotes from string
                        name = name.Trim('"');
                        var localFileName = file.LocalFileName;
                        var filePath = Path.Combine(root, name);



                        File.Move(localFileName, filePath);


                        var namee = provider.FormData.GetValues("ime")[0];
                        var lastname = provider.FormData.GetValues("prezime")[0];
                        var opisproblema = provider.FormData.GetValues("opis")[0];
                        var latitude = provider.FormData.GetValues("latitude")[0];
                        var longitude = provider.FormData.GetValues("longitude")[0];
                        var aktivan = "true";


                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "INSERT INTO [dezi-me].dbo.Data VALUES( @name, @lastname,@problemdescription,@latitude, @longitude, @imagepath, @aktivan)";
                        cmd.Parameters.AddWithValue("@name", namee);
                        cmd.Parameters.AddWithValue("@lastname", lastname);
                        cmd.Parameters.AddWithValue("@problemdescription", opisproblema);
                        cmd.Parameters.AddWithValue("@latitude", latitude);
                        cmd.Parameters.AddWithValue("@longitude", longitude);
                        cmd.Parameters.AddWithValue("@imagepath", filePath);
                        cmd.Parameters.AddWithValue("@aktivan", aktivan);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                }
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
            return "File uploaded!";

        }
    }
}