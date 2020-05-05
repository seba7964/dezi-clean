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
            var relativePath = root.Substring(root.Length - 6);

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
                        var relativePathInsert = Path.Combine(relativePath, name);



                        File.Move(localFileName, filePath);

                        
                        
                        var naslov = provider.FormData.GetValues("naslov").FirstOrDefault();
                        var namee = provider.FormData.GetValues("ime").FirstOrDefault();
                        var lastname = provider.FormData.GetValues("prezime").FirstOrDefault();
                        var opisproblema = provider.FormData.GetValues("opis").FirstOrDefault();
                        var latitude = provider.FormData.GetValues("latitude").FirstOrDefault();
                        var longitude = provider.FormData.GetValues("longitude").FirstOrDefault();
                        var datum = DateTime.Now.ToString("d/M/yyyy");
                        var kategorija = provider.FormData.GetValues("kategorija").FirstOrDefault().ToLower();
                        var boja = defineColor(kategorija);
                        var aktivan = "true";


                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "INSERT INTO [dezi-me].dbo.Data VALUES( @title,@name, @lastname,@problemdescription,@latitude, @longitude, @imagepath,@date,@category,@color,@aktivan)";
                        cmd.Parameters.AddWithValue("@title",naslov);
                        cmd.Parameters.AddWithValue("@name", namee);
                        cmd.Parameters.AddWithValue("@lastname", lastname);
                        cmd.Parameters.AddWithValue("@problemdescription", opisproblema);
                        cmd.Parameters.AddWithValue("@latitude", latitude);
                        cmd.Parameters.AddWithValue("@longitude", longitude);
                        cmd.Parameters.AddWithValue("@imagepath", relativePathInsert);
                        cmd.Parameters.AddWithValue("@date", datum);
                        cmd.Parameters.AddWithValue("@category", kategorija);
                        cmd.Parameters.AddWithValue("@color", boja);
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
            return "Uspješno ste prijavili problem!";

        }

        private string defineColor (string boja)
        {
            switch(boja) 
            {
                //crvena
                case "dezinfekcija":
                    return "#FF0000";
                //zelena
                case "dezinsekcija":
                    return "#008000";
                //plava
                case "deratizacija":
                    return "#0000FF";

                default: return "#FF0000";
            }

        }
    }
}