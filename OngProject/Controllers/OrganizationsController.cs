using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationsBusiness _organizationsBusiness;
        public OrganizationsController(IOrganizationsBusiness organizationsBusiness)
        {
            _organizationsBusiness = organizationsBusiness;
        }

        [HttpGet("public")]
        public async Task<IActionResult> GetAll() => Ok(await _organizationsBusiness.GetAll());

        [HttpGet("{Id}/[Action]")]
        public async Task<IActionResult> Slides(int Id) => Ok(await _organizationsBusiness.GetSlides(Id));

        [HttpPost]
        public async Task<IActionResult> Insert(List<InsertOrganizationDto> org) => Ok(await _organizationsBusiness.Insert(org));

        [HttpPost("/Public")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> Update (int Id, UpdateOrganizationDto organization)
            => Ok(await _organizationsBusiness.Update(Id, organization));
    }
}
