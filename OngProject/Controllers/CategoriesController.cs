using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
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
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
            {
            try
            {
                //IQueryable<CategorySearchIdDto> cat = _categoryBusiness.GetById(id);

                var result = await _categoryBusiness.GetById(id);

                if (result == null)
                {
                    return NotFound("Category ID does not exists.");
                }
                else
                {
                    return Ok(result);
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
