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
        [Route("FileUploadAsync/{type}")]
        public async Task<bool> FileUploadAsync([FromRoute]int type)
        {


            try
            {
                if (HttpContext.Request.Form.Files.Any())
                {
                    //foreach (var file in HttpContext.Request.Form.Files)
                    //{
                    //    var path = Path.Combine(_webHostEnvironment.ContentRootPath, "upload", file.FileName);
                    //    using (var stream = new FileStream(path, FileMode.Create))
                    //    {
                    //        await file.CopyToAsync(stream);
                    //    }
                    //}
                    string fileWay = string.Empty;
                    var file = HttpContext.Request.Form.Files.FirstOrDefault();
                    string name = file.Name;
                    string fileName = Path.GetFileName(file.FileName);
                    if(type == 1)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\image\" + @"\");

                    }
                    else if(type == 2)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\image\vehicle" + @"\");
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
  