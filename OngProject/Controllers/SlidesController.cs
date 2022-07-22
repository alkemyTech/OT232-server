using Microsoft.AspNetCore.Authentication.JwtBearer;
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

        public SlidesController(ISlidesBusiness slideBusiness)
        {
            _slideBusiness = slideBusiness;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> GetAll() => Ok(await _slideBusiness.GetAll());

        [HttpGet("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> GetById(int Id) => Ok(await _slideBusiness.GetById(Id));

        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> Insert(InsertSlideDto slideDto) => Ok(await _slideBusiness.Insert(slideDto));

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        [Route("{Id}")]
        public async Task<IActionResult> Update(UpdateSlidesDto slides, int Id) => Ok(await _slideBusiness.Update(slides, Id));

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id) => Ok(await _slideBusiness.Delete(id));
    }
}
