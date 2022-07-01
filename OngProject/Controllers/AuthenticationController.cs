using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using OngProject.Core.Mapper;

namespace OngProject.Controllers
{

    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationBusiness _authenticationBusiness;
        private readonly IEmailSender _emailSender;

        public AuthenticationController(IAuthenticationBusiness authenticationBusiness , IEmailSender emailSender)
        {
            _authenticationBusiness = authenticationBusiness;
            _emailSender = emailSender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            request.Password = CryptographyHelper.CreateHashPass(request.Password);

            var Exists = await _authenticationBusiness.UserExists(UserMapper.ToLoginUser(request));

            if (Exists.Count > 0)
                return BadRequest();

            if (!await _authenticationBusiness.UserRegister(request))
                return NotFound();

            await _emailSender.SendWelcomeEmailAsync(request.Email, "!");

            return Ok(await _authenticationBusiness.GetToken(UserMapper.ToLoginUser(request)));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto user)
        {
            user.Password = CryptographyHelper.CreateHashPass(user.Password);
            var Exists = await _authenticationBusiness.UserExists(user);

            if (Exists.Count > 0)
                return Ok(await _authenticationBusiness.GetToken(user));

            return NotFound();
        }
    }
}
