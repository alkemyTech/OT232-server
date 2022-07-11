using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactsBusiness _contactsBusiness;
        public ContactsController(IContactsBusiness contactsBusiness, IUnitOfWork unitOfWork)
        {
            _contactsBusiness = contactsBusiness;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> GetAll() => Ok(await _contactsBusiness.GetAll());

        [HttpGet("{Id})")]
        public IActionResult GetById(int id)
        {
            return NoContent();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Estándar")]
        public async Task<IActionResult> Insert(List<InsertContactDto> contact) => Ok(await _contactsBusiness.Insert(contact));

        [HttpPut]
        public IActionResult Update(Contact entity)
        {
            return NoContent();
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Estándar")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var result = await _contactsBusiness.Delete(Id);
                if (result.Succeeded == false)
                {
                    return StatusCode(403, result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                var response = new Response<string>()
                {
                    Data = "Error - 404",
                    Message = ex.Message,
                    Succeeded = false
                };
                return StatusCode(404, response);
            }
        }
    }
}