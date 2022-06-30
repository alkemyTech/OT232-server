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
            request.Password = cryp.CreateHashPass(request.Password);

            var Exists = await _authenticationBusiness.UserExists(UserMapper.ToLoginUser(request));

            if (Exists.Count > 0)
                return BadRequest();

            if (!await _authenticationBusiness.UserRegister(request))
                return NotFound();

            return Ok(await _authenticationBusiness.GetToken(UserMapper.ToLoginUser(request)));
        }

        [HttpPost("login")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto user)
        {
            user.Password = cryp.CreateHashPass(user.Password);
            var Exists = await _authenticationBusiness.UserExists(user);

            if (Exists.Count > 0)
            {
                return Ok(await _authenticationBusiness.GetToken(user));

            }
            return NotFound();
        }
    }
}
