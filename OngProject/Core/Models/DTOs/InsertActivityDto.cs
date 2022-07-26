using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class InsertActivityDto
    {
        [Required(ErrorMessage = "El atributo debe ser string.")]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[Null]")]
        public string Image { get; set; }
    }
}