using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class InsertTestimonialDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Required(ErrorMessage = "El contenido es obligatorio.")]
        public string Content { get; set; }
    }
}
