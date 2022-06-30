﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("auth")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {
        public readonly UserPasswordDto user = new UserPasswordDto();
        private readonly CryptographyHelper cryp = new CryptographyHelper();
        private readonly IAuthenticationBusiness _authenticationBusiness;

        public AuthenticationController(IAuthenticationBusiness authenticationBusiness)
        {
            _authenticationBusiness = authenticationBusiness;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            //user.User = request.Email;
            request.Password = cryp.CreateHashPass(request.Password);
            await _authenticationBusiness.UserRegister(request);

            return Ok("Usuario Registrado con éxito");
        }
    }
}
