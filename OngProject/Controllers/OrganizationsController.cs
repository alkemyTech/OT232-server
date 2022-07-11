using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationsBusiness _organizationsBusiness;
        public OrganizationsController(IOrganizationsBusiness organizationsBusiness, IUnitOfWork unitOfWork)
        {
            _organizationsBusiness = organizationsBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _organizationsBusiness.GetAll());

        [HttpGet("{Id})")]
        public IActionResult GetById(int id)
        {
            return NoContent();
        }

        [HttpPost]
        public IActionResult Insert(Organization entity)
        {
            return NoContent();
        }

        [HttpPost("/Public")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> Update (int Id, UpdateOrganizationDto organization) 
            => Ok(await _organizationsBusiness.Update(Id, organization));
        

        [HttpDelete]
        public IActionResult Delete(Organization entity)
        {
            return NoContent();
        }


    }
}
