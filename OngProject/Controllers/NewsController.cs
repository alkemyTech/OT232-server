using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly INewsBusiness _newsBusiness;
        public NewsController(INewsBusiness newsBusiness)
        {
            _newsBusiness = newsBusiness;
        }

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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {   

                var model = await _newsBusiness.Delete(id);
                if (model == null)
                {
                    return NotFound("no se encuentra el registro");
                }else
                { 
                return Ok("se borro el registro correctamente");
                }
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
