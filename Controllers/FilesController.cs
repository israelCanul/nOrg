using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace narilearsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        public FilesController(IHostingEnvironment environment) {
            _hostingEnvironment = environment;
        }
        [HttpGet]
        public IActionResult Get() {
            return Ok("OK");
        }
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
                     

            // full path to file in temp location
            var filePath = @"f:\";

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }

		// [HttpPost("upload")]
  //       public async Task<IActionResult> Post(List<IFormFile> files)
  //       {
  //           long size = files.Sum(f => f.Length);


  //           // full path to file in temp location
  //           var filePath = @"/Users/icanul/Documents/RepositoriosRoyal";
  //           var outputStream = new MemoryStream();
  //           foreach (var formFile in files)
  //           {
  //               if (formFile.Length > 0)
  //               {

  //                   using (var inputStream = formFile.OpenReadStream())
  //                   using (Image<Rgba32> image = Image.Load(inputStream))
  //                   {
  //                       image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2).Grayscale());
  //                       image.SaveAsJpeg<Rgba32>(outputStream);
  //                   }
  //                   outputStream.Seek(0, SeekOrigin.Begin);
  //               }
  //           }

  //           // process uploaded files
  //           // Don't rely on or trust the FileName property without validation.

  //           return File(outputStream, "image/jpg");

  //       }


    }
}