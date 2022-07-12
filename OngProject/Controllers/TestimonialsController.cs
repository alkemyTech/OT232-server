using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : Controller
    {
        private readonly ITestimonialsBusiness _testimonialsBusiness;

        public TestimonialsController(ITestimonialsBusiness testimonialsBusiness)
        {
            _testimonialsBusiness = testimonialsBusiness;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{Id})")]
        public IActionResult GetById(int Id)
        {
            return Ok();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> Insert(List<InsertTestimonialDto> testimonialsDtos) => Ok(await _testimonialsBusiness.Insert(testimonialsDtos));

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        [Route("{Id}")]
        public async Task<IActionResult> Update(UpdateTestimonialDto testimonial, int Id) => Ok(await _testimonialsBusiness.Update(testimonial, Id));

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id) => Ok(await _testimonialsBusiness.Delete(id));
    }
}
