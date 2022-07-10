using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class InsertContactDto
    {
        [Required(ErrorMessage = "El atributo debe ser string.")]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Email { get; set; }
        public int Phone { get; set; }

        [StringLength(255)]
        public string Message { get; set; }
    }
}