using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// WebApi Gestion de Categorías
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesBusiness _categoryBusiness;

        public CategoriesController(ICategoriesBusiness categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }


        // GET: /Categories
        /// <summary>
        /// Obtiene todos los registros de Categorías.
        /// </summary>
        /// <remarks>
        /// Obtiene los registros sólo con sus nombres exceptuando los eliminados.
        /// Para hacer uso de ésta acción, se requiere estar logueado con un usuario administrador.
        /// </remarks>
        /// <response code="200">Ok. Devuelve objeto con 4 (cuatro) propiedades: Data (datos solicitados), Succeeded (solicitud exitosa o no), Errors (Errores), Message (Mensaje de error específico).</response>
        /// <response code="401">Unauthorized. El usuario logueado no tiene el rol de administrador.</response>
        /// <response code="404">Not Found. No se ha encontrado.</response>
        /// <response code="500">Internal Server Error. Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll() => Ok(await _categoryBusiness.GetAll());


        // GET: /Categories/1
        /// <summary>
        /// Obtiene un registro de Categorías por su Id.
        /// </summary>
        /// <remarks>
        /// Obtiene un registro con todos sus campos por su Id.
        /// </remarks>
        /// <response code="200">Ok. Devuelve objeto con 4 (cuatro) propiedades: Data (datos solicitados), Succeeded (solicitud exitosa o no), Errors (Errores), Message (Mensaje de error específico).</response>
        /// <response code="401">Unauthorized. El usuario logueado no tiene el rol de administrador.</response>
        /// <response code="404">Not Found. No se ha encontrado.</response>
        /// <response code="500">Internal Server Error. Error interno del servidor.</response>
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int Id) => Ok(await _categoryBusiness.GetById(Id));


        // POST: /Categories
        /// <summary>
        /// Inserta un registro de Categorías.
        /// </summary>
        /// <remarks>
        /// Agrega un registro con los campos solicitados.
        /// </remarks>
        /// <response code="200">Ok. Devuelve objeto con 4 (cuatro) propiedades: Data (datos solicitados), Succeeded (solicitud exitosa o no), Errors (Errores), Message (Mensaje de error específico).</response>
        /// <response code="401">Unauthorized. El usuario logueado no tiene el rol de administrador.</response>
        /// <response code="404">Not Found. No se ha encontrado.</response>
        /// <response code="500">Internal Server Error. Error interno del servidor.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert(CategoryRequestDto request) => Ok(await _categoryBusiness.Insert(request));


        // PUT: /Categories/1
        /// <summary>
        /// Actualiza un registro de Categorías ya existente.
        /// </summary>
        /// <remarks>
        /// Actualiza un registro con los campos solicitados a partir de su Id cargado en la Base de Datos.
        /// </remarks>
        /// <response code="200">Ok. Devuelve objeto con 4 (cuatro) propiedades: Data (datos solicitados), Succeeded (solicitud exitosa o no), Errors (Errores), Message (Mensaje de error específico).</response>
        /// <response code="401">Unauthorized. El usuario logueado no tiene el rol de administrador.</response>
        /// <response code="404">Not Found. No se ha encontrado.</response>
        /// <response code="500">Internal Server Error. Error interno del servidor.</response>
        [HttpPut]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int Id, UpdateCategoryDto category) => Ok(await _categoryBusiness.Update(category, Id));


        // DELETE: Categories/1
        /// <summary>
        /// Elimina un registro de Categorías ya existente.
        /// </summary>
        /// <remarks>
        /// Elimina lógicamente a partir del Id solicitado.
        /// </remarks>
        /// <response code="200">Ok. Devuelve objeto con 4 (cuatro) propiedades: Data (datos solicitados), Succeeded (solicitud exitosa o no), Errors (Errores), Message (Mensaje de error específico).</response>
        /// <response code="401">Unauthorized. El usuario logueado no tiene el rol de administrador.</response>
        /// <response code="404">Not Found. No se ha encontrado.</response>
        /// <response code="500">Internal Server Error. Error interno del servidor.</response>
        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int Id) => Ok(await _categoryBusiness.Delete(Id));
  
    }
}
