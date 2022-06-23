using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
            [HttpGet]
            public IActionResult GetAll()
            {
                return Ok();
            }

            [HttpGet]
            public IActionResult GetById(int id)
            {
                return Ok();
            }

            [HttpPost]
            public IActionResult Insert()
            {
                return Ok();
            }

            [HttpPut]
            public IActionResult Update()
            {
                return Ok();
            }

            [HttpDelete]
            public IActionResult Delete(int id)
            {
                return Ok();
            }
    }
}
