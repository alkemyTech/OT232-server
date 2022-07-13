﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly ICommentsBusiness _commentsBusiness;
        public CommentsController(ICommentsBusiness commentsBusiness)
        {
            _commentsBusiness = commentsBusiness;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]

        public async Task<IActionResult> GetAll() => Ok(await _commentsBusiness.GetAll());


        [HttpGet("{Id})")]
        public IActionResult GetById(int Id)
        {
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(List<InsertCommentDto> commentDtos) => Ok(await _commentsBusiness.Insert(commentDtos));

        [HttpPut]
        [Route("{Id}")]

        public async Task<IActionResult> Update(UpdateCommentDto commentDto, int Id) => Ok(await _commentsBusiness.Update(commentDto, Id));

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var result = await _commentsBusiness.Delete(Id);
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