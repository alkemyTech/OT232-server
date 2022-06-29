using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

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
        public IActionResult GetAll()
        {
            return NoContent();
        }

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

        [HttpPut]
        public IActionResult Update(Organization entity)
        {
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Organization entity)
        {
            return NoContent();
        }


    }
}
