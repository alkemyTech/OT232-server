using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class InsertCommentDto
    {
        [Required(ErrorMessage = "ID usuario necesario")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Se requiene NewsID")]
        public int NewsID  { get; set; }

        [Required(ErrorMessage = "El Comentario es obligatorio.")]
        public string Body { get; set; }
    }
}