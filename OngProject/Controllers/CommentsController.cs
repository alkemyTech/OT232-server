using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly ICommentsBusiness _commentsBusiness;
        public CommentsController(ICommentsBusiness commentsBusiness)
        {
            _commentsBusiness = commentsBusiness;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return NoContent();
        }

        [HttpGet("{Id})")]
        public IActionResult GetById(int Id)
        {
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(List<InsertCommentDto> commentDtos) => Ok(await _commentsBusiness.Insert(commentDtos));

        [HttpPut]
        public IActionResult Update()
        {
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return NoContent();
        }
    }
}