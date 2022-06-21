using Microsoft.AspNetCore.Mvc;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlideController : Controller
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return NoContent();
        }

        [HttpPost]
        public IActionResult Insert()
        {
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update()
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
