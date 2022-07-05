using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
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

        [HttpGet("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> GetById(int Id) => Ok(await _newsBusiness.GetById(Id));

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> Insert(InsertNewsDto dto) => Ok(await _newsBusiness.Insert(dto));

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
        [HttpGet("{id}/[Action]")]
        public async Task<Response<List<CommentDto>>> Comments(int id)
        {
            try
            {
                var entity = await _newsBusiness.GetComments(id);
                if (entity == null)
                    return new Response<List<CommentDto>>(entity, false, null, ResponseMessage.NotFound);
                return new Response<List<CommentDto>>(entity, true, null, ResponseMessage.Success);
            }
            catch (Exception ex)
            {
                return new Response<List<CommentDto>>(null, false, null, ResponseMessage.UnexpectedErrors);
            }
        }
    }
}
