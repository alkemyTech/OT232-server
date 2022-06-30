using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;

using System.Threading.Tasks;

namespace OngProject.Controllers
{

    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public readonly UserPasswordDto user = new UserPasswordDto();
        private readonly CryptographyHelper cryp = new CryptographyHelper();
     

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


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            request.Password = cryp.CreateHashPass(request.Password);
            if(!await _authenticationBusiness.UserRegister(request)) return BadRequest();
            
            return Ok("Usuario Registrado con éxito");
           }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto user)
        {
            //user.Password = CryptographyHelper.CreateHashPass(user.Password);
            var Exists = await _authenticationBusiness.UserExists(user);

            if (Exists.Count > 0)
            {
                return Ok(await _authenticationBusiness.GetToken(user));
            }
            return NotFound();

        }
    }
}
