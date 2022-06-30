using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IAmazonS3 amazons3;

        public ImageController(IAmazonS3 amazonS3)
        {
            this.amazons3 = amazonS3;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            var putRequest = new PutObjectRequest()
            {
                BucketName = "g232alkemy",
                Key = file.FileName,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType,

            };
            var result = await this.amazons3.PutObjectAsync(putRequest);
            return Ok("Imagen subida correctamente");
        }
    }
}
