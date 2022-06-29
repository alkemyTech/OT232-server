using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
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
