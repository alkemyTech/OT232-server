using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "El Email es obligatorio.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
