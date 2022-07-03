using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : Controller
    {
        private readonly IMembersBusiness _membersBussines;
        public MembersController(IMembersBusiness membersBussines, IUnitOfWork unitOfWork)
        {
            _membersBussines = membersBussines;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> GetAll() => Ok(await _membersBussines.GetAll());

        [HttpGet("{Id})")]
        public IActionResult GetById(int id)
        {
            return NoContent();
        }

        [HttpPost]
        public IActionResult Insert(Member entity)
        {
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Member entity)
        {
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Member entity)
        {
            return NoContent();
        }


    }
}
