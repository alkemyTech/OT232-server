using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class UpdateSlidesDto
    {
        [Required(ErrorMessage = "La URL  es obligatoria.")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "El texto es obligatorio.")]
        public string Text { get; set; }
        [Required(ErrorMessage = "El orden es obligatorio.")]
        public int Order { get; set; }
        [Required(ErrorMessage = "El Id de la organizacion es obligatorio.")]
        public int OrganizationId { get; set; }
    }
}
