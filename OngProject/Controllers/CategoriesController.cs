using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.Interfaces;


namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : Controller
    {
        private readonly ICategoriesBusiness _categoriesBusiness;

        public CategoriesController(ICategoriesBusiness categoriesBusiness)
        {
            _categoriesBusiness = categoriesBusiness;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
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
