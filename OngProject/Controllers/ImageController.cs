using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAmazonS3 _amazons3;
        private readonly IImageHelper _imageHelper;

        public ImageController(IAmazonS3 amazonS3, IImageHelper imageHelper)
        {
            _amazons3 = amazonS3;
            _imageHelper = imageHelper;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<string> UploadFile(IFormFile file) 
        {
            return await _imageHelper.UploadFile(file);
        }
    }
}
