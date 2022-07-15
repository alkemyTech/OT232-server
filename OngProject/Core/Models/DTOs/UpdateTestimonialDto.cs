using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class UpdateTestimonialDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La imagen es obligatoria.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "El contenido es obligatorio.")]
        public string Content { get; set; }
    }
}
