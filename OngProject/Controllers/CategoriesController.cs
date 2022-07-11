using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> GetAll(int Page = 1) => Ok(await _categoryBusiness.GetAll(Page));

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> Categories(CategoryRequestDto request)
        {
            if (!await _categoryBusiness.Insert(request))
                return NotFound();

            return Ok("Categoria Añadida Correctamente");
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update(UpdateCategoryDto category, int Id) => Ok(await _categoryBusiness.Update(category, Id));

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) => Ok(await _categoryBusiness.Delete(id));
  
    }
}
