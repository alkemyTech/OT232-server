using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class UpdateToNewsDto
    {
        [Required(ErrorMessage = "El name es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "la Description es obligatorio.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "La image es obligatorio.")]
        public string Image { get; set; }
        [Required(ErrorMessage = "La categoria es  obligatoria.")]
        public int CategoryId { get; set; }


    }
}
