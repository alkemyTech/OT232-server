using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Estándar")]
        public async Task<IActionResult> GetAll(int Page = 1) => Ok(await _testimonialsBusiness.GetAll(Page));


        [HttpGet("{Id})")]
        public IActionResult GetById(int Id)
        {
            return Ok();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> Insert(List<InsertTestimonialDto> testimonialsDtos) => Ok(await _testimonialsBusiness.Insert(testimonialsDtos));

        [HttpPut]
        public IActionResult Update()
        {
            return Created("", null);
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id) => Ok(await _testimonialsBusiness.Delete(id));
    }
}
