using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    /// WebApi Gestion de Activities
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController : Controller
    {
        private readonly IActivitiesBusiness _activitiesBusiness;
        public ActivitiesController(IActivitiesBusiness activitiesBusiness)
        {
            _activitiesBusiness = activitiesBusiness;
        }

        // GET: /activities
        /// <summary>
        /// Obtiene una lista de Actividades.
        /// </summary>
        /// <remarks>
        /// Obtiene una lista de Actividades.
        /// </remarks>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Devuelve una lista de actividades.</response>        
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
        public async Task<IActionResult> GetAll() => Ok(await _activitiesBusiness.GetAll());

        // POST: /activities
        /// <summary>
        /// Crea una Actividad y la añade a la BD.
        /// </summary>
        /// <remarks>
        /// Crea una Actividad y la añade a la BD.
        /// 
        /// Sample Request:
        /// 
        ///     Form-Data
        ///     {
        ///        "name": "Nombre de la actividad",
        ///        "content": "Descripcion del contenido de la actividad",
        ///        "image": "imagen como string($binary)",
        ///     }
        /// </remarks>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Agrega la nueva actividad a la BD.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPost]
        public async Task<IActionResult> Insert(List<InsertActivityDto> activity) => Ok(await _activitiesBusiness.Insert(activity));


        // PUT: /activities
        /// <summary>
        /// Actualiza una Actividad y de la BD.
        /// </summary>
        /// <remarks>
        /// Actualiza una Actividad y de la BD.
        /// </remarks>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Actualiza la actividad en la BD.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, UpdateActivityDto entity) => Ok(await _activitiesBusiness.Update(Id, entity));

        // DELETE: /activities/5
        /// <summary>
        /// Elimina una Actividad y la quita de la BD a través de un Id.
        /// </summary>
        /// <remarks>
        /// Elimina una Actividad y la quita de la BD a través de un Id.
        /// </remarks>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Elimina la actividad de la BD.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Estándar")]
        public async Task<IActionResult> Delete(int Id) => Ok(await _activitiesBusiness.Delete(Id));
    }
}