using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using System;
using System.Threading.Tasks;


namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController: ControllerBase
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

        private IActionResult Ok()
        {
            throw new NotImplementedException();
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

        private IActionResult Created(string v, object value)
        {
            throw new NotImplementedException();
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
