using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
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
        [Authorize(Roles = "Administrador")]
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
