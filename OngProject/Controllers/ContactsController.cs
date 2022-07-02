using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsBusiness _contactsBusiness;
        public  ContactsController(IContactsBusiness contactsBusiness)
        {
            _contactsBusiness = contactsBusiness;

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> GetAll() => Ok(await _contactsBusiness.GetAll());

        [HttpGet("{Id})")]
        public async Task<IActionResult> GetById(int Id) => Ok(await _contactsBusiness.GetById(Id));

        [HttpPost]
        public IActionResult Insert()
        {
            return Created("", null);
        }

        [HttpPut("{Id})")]
        public async Task<IActionResult> Update(int Id)
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
