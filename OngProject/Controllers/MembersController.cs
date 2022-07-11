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
    public class MembersController : Controller
    {
        private readonly IMembersBusiness _membersBusiness;
        public MembersController(IMembersBusiness membersBussines, IUnitOfWork unitOfWork)
        {
            _membersBusiness = membersBussines;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> GetAll() => Ok(await _membersBusiness.GetAll());

        [HttpGet("{Id})")]
        public IActionResult GetById(int id)
        {
            return NoContent();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Estándar")]
        public async Task<IActionResult> Insert(List<InsertMemberDto> member) => Ok(await _membersBusiness.Insert(member));

        [HttpPut]
        public IActionResult Update(Member entity)
        {
            return NoContent();
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Estándar")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var result = await _membersBusiness.Delete(Id);
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
