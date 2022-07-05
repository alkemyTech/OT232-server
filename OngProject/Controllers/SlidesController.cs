﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlidesController : Controller
    {
        private readonly ISlidesBusiness _slideBusiness;

        public SlidesController(ISlidesBusiness slideBusiness, IUnitOfWork unitOfWork)
        {
            _slideBusiness = slideBusiness;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> GetAll() => Ok(await _slideBusiness.GetAll());

        [HttpGet("{Id})")]
        public IActionResult GetById()
        {
            return NoContent();
        }

        [HttpPost]
        public IActionResult Insert()
        {
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update()
        {
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return NoContent();
        }
    }
}