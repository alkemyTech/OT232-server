﻿using Amazon.S3;
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
        private readonly IAmazonS3 _amazons3;
        private readonly IImageHelper _imageHelper;

        public ImageController(IAmazonS3 amazonS3, IImageHelper imageHelper)
        {
            _amazons3 = amazonS3;
            _imageHelper = imageHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            await _imageHelper.UploadFile(file);

            return Ok("Imagen subida correctamente");
        }
    }
}
