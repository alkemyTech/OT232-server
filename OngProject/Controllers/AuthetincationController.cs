using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Helper;
using OngProject.Core.Models.DTOs;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("auth")]
    [ApiController]

    public class AuthetincationController : ControllerBase
    {
        public readonly UserPasswordDto user = new UserPasswordDto();
        private readonly CryptographyHelper cryp = new CryptographyHelper();

        [HttpPost("register")]
        public IActionResult Register(RegisterRequestDto request)
        {           
            user.User = request.Email;
            user.PasswordEncrypted = cryp.CreateHashPass(request.Password);

            return Ok(user);
        }
    }
}
