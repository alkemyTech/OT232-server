using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("auth/")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationBusiness _authenticationBusiness;

        public AuthenticationController(IAuthenticationBusiness authenticationBusiness)
        {
            _authenticationBusiness = authenticationBusiness;
        }

        [HttpPost("login")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto user)
        {
            user.Password = CryptographyHelper.CreateHashPass(Password);

            if(await _authenticationBusiness.UserExists(user))
            {
                return Ok(_authenticationBusiness.GetToken(user));
            }

            return Ok(false);
        }
    }
}
