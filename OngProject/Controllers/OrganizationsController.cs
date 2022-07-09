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
        private readonly IUnitOfWork _unitOfWork;
        public OrganizationsController(IOrganizationsBusiness organizationsBusiness, IUnitOfWork unitOfWork)
        {
            _organizationsBusiness = organizationsBusiness;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _organizationsBusiness.GetAll());

        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            return NoContent();
        }

        [HttpGet("{Id}/[Action]")]
        public async Task<List<SlideOrganizationDto>> Slides(int Id)
        {
            var entity = await _organizationsBusiness.GetSlides(Id);
            return entity;
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
