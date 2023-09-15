using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portathon_Hackathon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadFileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
<<<<<<< HEAD
        [Route("FileUploadAsync/{type}")]
        public async Task<bool> FileUploadAsync([FromRoute]int type)
=======
        [Route("FileUploadAsync/{fileContent}")]
        public async Task<bool> FileUploadAsync([FromRoute]int fileContent)
>>>>>>> b7796df013d6e994696c8439fae0c7b728fcec6c
        {


            try
            {
                if (HttpContext.Request.Form.Files.Any())
                {
<<<<<<< HEAD
                    //foreach (var file in HttpContext.Request.Form.Files)
                    //{
                    //    var path = Path.Combine(_webHostEnvironment.ContentRootPath, "upload", file.FileName);
                    //    using (var stream = new FileStream(path, FileMode.Create))
                    //    {
                    //        await file.CopyToAsync(stream);
                    //    }
                    //}
=======
>>>>>>> b7796df013d6e994696c8439fae0c7b728fcec6c
                    string fileWay = string.Empty;
                    var file = HttpContext.Request.Form.Files.FirstOrDefault();
                    string name = file.Name;
                    string fileName = Path.GetFileName(file.FileName);
<<<<<<< HEAD
                    if(type == 1)
=======
                    if (fileContent == 1)
>>>>>>> b7796df013d6e994696c8439fae0c7b728fcec6c
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\image\" + @"\");

                    }
<<<<<<< HEAD
                    else if(type == 2)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\image\vehicle" + @"\");
=======
                    else if (fileContent == 2)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\image\vehicles" + @"\");
>>>>>>> b7796df013d6e994696c8439fae0c7b728fcec6c
                        fileWay = filePath;
                    }
                    fileWay = fileWay.Replace("\\Server\\", "\\Client\\");
                    if (!Directory.Exists(fileWay))
                    {
                        Directory.CreateDirectory(fileWay);
                    }
                    using (var stream = new FileStream(fileWay + fileName, FileMode.OpenOrCreate))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }



        }


    }
}
  