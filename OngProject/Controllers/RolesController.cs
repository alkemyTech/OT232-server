using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
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
        public IActionResult Insert()
        {
            return Created("", null);
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Created("", null);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}