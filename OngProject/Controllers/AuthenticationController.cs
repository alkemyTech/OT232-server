using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using OngProject.Core.Mapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace OngProject.Controllers
{

    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationBusiness _authenticationBusiness;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _accesor;

        public AuthenticationController(IAuthenticationBusiness authenticationBusiness , IEmailSender emailSender, IHttpContextAccessor accesor)
        {
            _authenticationBusiness = authenticationBusiness;
            _emailSender = emailSender;
            _accesor = accesor;
        }
        // POST: /Register
        /// <summary>
        /// Crea un Usuario en la BD.
        /// </summary>
        /// <remarks>
        /// Crea un nuevo usuario con los datos solicitados.
        /// 
        /// Sample Request:
        /// 
        ///                     FirstName = Nombre del usuario
        ///                     LastName = Apellido del usuario
        ///                     Email = Email del usuario
        ///                     Password = Password que se va a utilizar
        ///                     RoleID = El rol por defecto es 2.
        /// </remarks>

        /// <response code="200">Ok. Objeto correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response> 
        /// <response code="500">InternalServerError, Error del servidor</response>
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
        /// <summary>
        /// Autentifica la informacion de los usuarios registrados.
        /// </summary>
        /// <returns>retorna el JwtToken y un status Message</returns>
        /// <remarks>
        /// La informacion solicitada es
        /// 
        /// Sample request:
        /// 
        ///     POST / LOGIN
        ///     {
        ///         "email": "User@email.com",  *Required
        ///         "password": "ExamplePassword"  *Required
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Retorna el JWT.</response>        
        /// <response code="400">BadRequest. Formato del objeto incorrecto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response> 
        /// <response code="500">InternalServerError, Error del servidor</response>

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto user)
        {
            user.Password = CryptographyHelper.CreateHashPass(user.Password);
            var Exists = await _authenticationBusiness.UserExists(user);

            if (Exists.Count > 0)
                return Ok(await _authenticationBusiness.GetToken(user));

            return NotFound();
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMe() 
        {
            int Id = Convert.ToInt32(_accesor.HttpContext.User.Claims.FirstOrDefault(u => u.Type == "Id").Value);
            return Ok(await _authenticationBusiness.GetById(Id));
        }
    }
}
