using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
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

        private readonly ICategoriesBusiness _categoryBusiness;

        public CategoriesController(ICategoriesBusiness categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }

        [HttpGet]
            public IActionResult GetAll()
            {
                return Ok();
            }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetById(int id)
            {
            try
            {
          
                var list = _categoryBusiness.GetById(id);

                if (list == null)
                {
                    return NotFound("Category ID does not exists.");
                }
                else
                {
                    return Ok(list);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
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
