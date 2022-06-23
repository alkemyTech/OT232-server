using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : Controller
    {
        private readonly IMembersBussines _membersBussines;
        public MembersController(IMembersBussines membersBussines, IUnitOfWork unitOfWork)
        {
            _membersBussines = membersBussines;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return NoContent();
        }

        [HttpPost]
        public IActionResult Insert(Members entity)
        {
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Members entity)
        {
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Members entity)
        {
            return NoContent();
        }


    }
}
