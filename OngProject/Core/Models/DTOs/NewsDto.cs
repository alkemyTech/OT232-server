
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class NewsDto
    {
        [Required(ErrorMessage = "El name es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "la Description es obligatorio.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "La image es obligatorio.")]
        public string Image { get; set; }
    }
}
