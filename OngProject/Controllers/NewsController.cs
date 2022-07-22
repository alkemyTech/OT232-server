using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// WebApi  Gestión de Novedades
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly INewsBusiness _newsBusiness;
        public NewsController(INewsBusiness newsBusiness)
        {
            _newsBusiness = newsBusiness;
        }

        // GET: /news
        /// <summary>
        /// Obtiene una lista de novedades.
        /// </summary>
        /// <remarks>
        /// Obtiene una lista de novedades.
        /// </remarks>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no está indicado.</response>              
        /// <response code="200">OK. Devuelve una lista de novedades.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la petición.</response>
        /// <response code="500">InternalServerError. Error interno del servidor</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <returns></returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Estándar")]
        public async Task<IActionResult> GetAll(int Page = 1) => Ok(await _newsBusiness.GetAll(Page));

        // GET: /news/5
        /// <summary>
        /// Obtiene una novedad por su Id.
        /// </summary>
        /// <remarks>
        /// Obtiene una novedad por su Id especificada en la URL.
        /// </remarks>
        /// <param name="Id">Id del objeto.</param>
        /// <response code="401">Unauthorized. El Token JWT de acceso es incorrecto o no está indicado.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la petición.</response>
        /// <response code="500">InternalServerError. Error interno del servidor</response>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> GetById(int Id) => Ok(await _newsBusiness.GetById(Id));

        // POST: /news
        /// <summary>
        /// Crea una novedad en la base de datos.
        /// </summary>
        /// <remarks>
        /// Crea un nuevo objeto en la base de datos recibiendo los datos de un form.
        /// 
        /// Sample Request:
        /// 
        ///     Form-Data
        ///     {
        ///        "name": "Nombre de la novedad",
        ///        "description": "Descripción de la novedad",
        ///        "image": "imagen como string($binary)",
        ///        "categoryId": "Id de la categoría de la novedad (un entero)"
        ///     }
        /// </remarks>
        /// <param name="dto">Objeto a crear a la base de datos.</param>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no está indicado.</response>
        /// <response code="200">Ok. Objeto correctamente creado en la base de datos.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la base de datos. Formato del objeto incorrecto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response> 
        /// <response code="500">InternalServerError. Error interno del servidor</response>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<IActionResult> Insert(InsertNewsDto dto) => Ok(await _newsBusiness.Insert(dto));

        // PUT: /news/5
        /// <summary>
        /// Actualiza una novedad en la base de datos.
        /// </summary>
        /// <remarks>
        /// Actualiza un nuevo objeto en la base de datos, recibiendo los datos de un Json, y buscando el objeto por su Id.
        /// 
        /// Sample request:
        ///
        ///     PUT /news/5
        ///     {
        ///        "name": "Nombre actualizado de la novedad",
        ///        "description": "Descripción actualizada de la novedad",
        ///        "image": "Imagen como string($binary)",
        ///        "categoryId": "Id actualizado de la categoría de la novedad",
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no está indicado.</response>
        /// <response code="200">Ok. Objeto correctamente actualizado en la base de datos.</response>   
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError. Error interno del servidor</response>
        /// <returns></returns>
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        [Route("{Id}")]
        public async Task<IActionResult> Update(UpdateToNewsDto news, int Id) => Ok(await _newsBusiness.Update(news, Id));

        // DELETE: api/news/5
        /// <summary>
        /// Elimina una novedad por su Id.
        /// </summary>
        /// <remarks>
        /// Elimina de la base de datos una novedad por su Id especificada en la URL. Realiza un SoftDelete, cambiando un tag a false.
        /// </remarks>
        /// <param name="Id">Id de la novedad.</param>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Objeto borrado correctamente.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError. Error internodel servidor</response>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id) => Ok(await _newsBusiness.Delete(Id));

        // ACTION: api/news/5/commments
        /// <summary>
        /// Devuelve una lista de los comentarios de una novedad por su Id.
        /// </summary>
        /// <remarks>
        /// Devuelve una lista de los comentarios de una novedad por su Id, especificada en la URL.
        /// </remarks>
        /// <param name="Id">Id del objeto.</param>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Objeto borrado correctamente.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError. Error interno del servidor</response>
        /// <returns></returns>
        [HttpGet("{id}/[Action]")]
        public async Task<Response<List<CommentDto>>> Comments(int id)
        {
            try
            {
                var entity = await _newsBusiness.GetComments(id);
                if (entity == null)
                    return new Response<List<CommentDto>>(entity, false, null, ResponseMessage.NotFound);
                return new Response<List<CommentDto>>(entity, true, null, ResponseMessage.Success);
            }
            catch (Exception ex)
            {
                return new Response<List<CommentDto>>(null, false, null, ResponseMessage.UnexpectedErrors);
            }
        }
    }
}
