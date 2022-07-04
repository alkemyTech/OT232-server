using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class InsertContactDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El email es obligatorio.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio.")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "El contenido es obligatorio.")]
        public string Message { get; set; }
    }
}
