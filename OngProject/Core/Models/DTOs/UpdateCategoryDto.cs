using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "El name es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La Descripcion es obligatorio.")]

        public string Description { get; set; }

        [Required(ErrorMessage = "La Image es obligatoria.")]
        public string Image { get; set; }
    }
}
