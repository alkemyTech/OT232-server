using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// WebApi  Gestion de Members
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : Controller
    {
        private readonly IMembersBusiness _membersBusiness;
        public MembersController(IMembersBusiness membersBussines, IUnitOfWork unitOfWork)
        {
            _membersBusiness = membersBussines;
        }
        // GET: /Members
        /// <summary>
        /// Obtiene una lista de miembros.
        /// </summary>
        /// <remarks>
        /// Obtiene una lista de todos los miembros.
        /// </remarks>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Devuelve una lista de testimonios.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <returns></returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> GetAll(int pageNumber = 1) => Ok(await _membersBusiness.GetAll(pageNumber));
        
        // POST: /Members
        /// <summary>
        /// Crea un Miembro en la BD.
        /// </summary>
        /// <remarks>
        /// Crea un nuevo objeto en la BD recibiendo los datos de un form.
        /// 
        /// Sample Request:
        /// 
        ///     Form-Data
        ///     {
        ///        "name": "Nombre del miembro a cargar",
        ///        "image": "imagen como string($binary)",
        ///         "Description": "Descripcion del usuario al querer cargar",
        ///        "FacebookUrl": "el Facebook del miembro que se crea",
        ///        "InstagramUrl": "el Instagram del Miembro que se crea",
        ///        "LinkedinUrl": "el linkedin del miembro que se crea"
        ///     }
        /// 
        /// </remarks>
        /// <param name="member">Objeto a crear a la BD.</param>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>
        /// <response code="200">Ok. Objeto correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response> 
        /// <response code="500">InternalServerError, Error del servidor</response>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Estándar")]
        public async Task<IActionResult> Insert(List<InsertMemberDto> member) => Ok(await _membersBusiness.Insert(member));


        // PUT: /Members/2
        /// <summary>
        /// Actualiza un Miembro en la BD.
        /// </summary>
        /// <remarks>
        /// Actualiza un nuevo objeto en la BD recibiendo los datos de un Json, y buscando el objeto por su id.
        /// 
        /// Sample request:
        ///
        ///     PUT/Members/5
        ///     {
        ///        "name": "nombre actualizado de la actividad",
        ///        "image": "imagen como string($binary)",
        ///        "Description": "contenido a actualizar",
        ///        "FacebookUrl": "el Facebook del miembro que se actualiza",
        ///        "InstagramUrl": "el Instagram del Miembro a actualizar",
        ///        "LinkedinUrl": "el linkedin de la persona a actualizar"
        ///     }
        ///     
        /// </remarks>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>
        /// <response code="200">Ok. Objeto correctamente actualizado en la BD.</response>   
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <returns></returns>
        /// 
        [HttpPut]
        [Route("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Estándar")]
        public async Task<IActionResult> Update(UpdateMemberDto member, int Id) => Ok(await _membersBusiness.Update(member, Id));


        // DELETE: api/Members/5
        /// <summary>
        /// Elimina a un miembro por su Id.
        /// </summary>
        /// <remarks>
        /// Elimina de la BD una members por su Id especificada en la url. Realiza un SoftDelete, cambiando un tag a false.
        /// </remarks>
        /// <param name="Id">Id del objeto.</param>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Objeto borrado correctamente.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Estándar")]
        public async Task<IActionResult> Delete(int Id) => Ok(await _membersBusiness.Delete(Id));
    }
}
