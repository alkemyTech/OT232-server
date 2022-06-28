using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System;
using System.Threading.Tasks;


namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {

        private readonly IActivitiesBusiness _activitiesBusiness;

        public ActivitiesController(IActivitiesBusiness activitiesBusiness)
        {
            _activitiesBusiness = activitiesBusiness;
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



        [HttpPut("{Id})")]
        public async Task<IActionResult> Update(int Id, UpdateActivityDto activity)
        {

            var model = await _activitiesBusiness.GetById(Id);
            if (model == null)
            {
                return NotFound();
            }
            var result = _activitiesBusiness.Update(model, activity);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok("Se actualizo correctamente el regitro" + Id);
            
        }

        [HttpDelete]
        public IActionResult Delete()
        {

            return Ok();
        }
    }
}
