using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class UpdateActivityDto
    {
        [Required(ErrorMessage = "El Id es obligatorio.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El name es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La content es obligatorio.")]
       
        public string Content { get; set; }

        [Required(ErrorMessage = "La Image es obligatoria.")]
        public string Image { get; set; }

    }
}
