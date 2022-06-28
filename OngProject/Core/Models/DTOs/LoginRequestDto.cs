using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "El email es obligatorio.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener un mínimo de 6 (seis) caracteres.")]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
