using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NSwag.Annotations;
using Microsoft.AspNetCore.Http;

namespace OngProject.Controllers
{
    /// <summary>
    /// WebApi  Gestion de Testionials
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : Controller
    {
        private readonly ITestimonialsBusiness _testimonialsBusiness;

        public TestimonialsController(ITestimonialsBusiness testimonialsBusiness)
        {
            _testimonialsBusiness = testimonialsBusiness;
        }

        // GET: /testimonials
        /// <summary>
        /// Obtiene una lista de  testimonios.
        /// </summary>
        /// <remarks>
        /// Obtiene una lista de testimonios.
        /// </remarks>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Devuelve una lista de testimonios.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <returns></returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Estándar")]
        public async Task<IActionResult> GetAll(int Page = 1) => Ok(await _testimonialsBusiness.GetAll(Page));

        // GET: /testimonials/5
        /// <summary>
        /// Obtiene un testimonio por su Id.
        /// </summary>
        /// <remarks>
        /// Obtiene un testimonio por su Id especificada en la url.
        /// </remarks>
        /// <param name="Id">Id del objeto.</param>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int Id)
        {
            return Ok();
        }

        // POST: /testimonials
        /// <summary>
        /// Crea un testimonio en la BD.
        /// </summary>
        /// <remarks>
        /// Crea un nuevo objeto en la BD recibiendo los datos de un form.
        /// 
        /// Sample Request:
        /// 
        ///     Form-Data
        ///     {
        ///        "name": "Nombre del testimonio",
        ///        "image": "imagen como string($binary)",
        ///        "content": "Descripcion del contenido del testimonio",
        ///     }
        /// 
        /// </remarks>
        /// <param name="testimonialsDtos">Objeto a crear a la BD.</param>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>
        /// <response code="200">Ok. Objeto correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response> 
        /// <response code="500">InternalServerError, Error del servidor</response>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert(List<InsertTestimonialDto> testimonialsDtos) => Ok(await _testimonialsBusiness.Insert(testimonialsDtos));


        // PUT: /Activities/5
        /// <summary>
        /// Actualiza una actividad en la BD.
        /// </summary>
        /// <remarks>
        /// Actualiza un nuevo objeto en la BD recibiendo los datos de un Json, y buscando el objeto por su id.
        /// 
        /// Sample request:
        ///
        ///     PUT /Testimonials/5
        ///     {
        ///        "name": "nombre actualizado de la actividad",
        ///        "image": "imagen como string($binary)",
        ///        "content": "contenido a actualizar"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>
        /// <response code="200">Ok. Objeto correctamente actualizado en la BD.</response>   
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <returns></returns>
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        [Route("{Id}")]
        public async Task<IActionResult> Update(UpdateTestimonialDto testimonial, int Id) => Ok(await _testimonialsBusiness.Update(testimonial, Id));



        // DELETE: api/Testimonial/5
        /// <summary>
        /// Elimina una actividad por su Id.
        /// </summary>
        /// <remarks>
        /// Elimina de la BD una actividad por su Id especificada en la url. Realiza un SoftDelete, cambiando un tag a false.
        /// </remarks>
        /// <param name="Id">Id del objeto.</param>
        /// <response code="401">Unauthorized.El Token JWT de acceso es incorrecto o no esta indicado.</response>              
        /// <response code="200">OK. Objeto borrado correctamente.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int Id) => Ok(await _testimonialsBusiness.Delete(Id));
    }
}
