using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUsersBusiness _userBusiness;

        public UserController(IUsersBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        // GET: /users
        /// <summary>
        /// Obtiene una lista de users.
        /// </summary>
        /// <remarks>
        /// Obtiene una lista de users.
        /// </remarks>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Devuelve una lista de users.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> GetAll() => Ok(await _userBusiness.GetAll());

        // PATCH: /User/1
        /// <summary>
        /// Actualiza la contraseña de User.
        /// </summary>
        /// <remarks>
        /// Actualiza el campo contraseña del Objeto User en la BD recibiendo los datos de un Json, y buscando el objeto por su id.
        /// 
        /// Sample request:
        ///
        ///     PATCH /User/1
        ///     {
        ///        "Password": "envia como string para encriptar contraseña"
        ///     }
        ///
        /// </remarks>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>
        /// <response code="200">Ok. campo contraseña del Objeto correctamente actualizado en la BD.</response>   
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <returns></returns>
        [HttpPatch("{Id}")]
        public async Task<IActionResult> Update(UpdateUserDto userDto, int Id) => Ok(await _userBusiness.Update(userDto, Id));

        // DELETE: api/User/1
        /// <summary>
        /// Elimina un usuario por su Id
        /// </summary>
        /// <remarks>
        /// Elimina de la BD un usuario por su Id especificada en la url. Realiza un SoftDelete, cambiando un tag a false.
        /// </remarks>
        /// <param name="id">Id del objeto.</param>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Objeto borrado correctamente.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <returns></returns>
        /// 
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id) => Ok(await _userBusiness.Delete(Id));

    }
}

