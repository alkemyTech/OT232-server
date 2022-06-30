using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class RegisterRequestDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required, MinLength(6, ErrorMessage = "La contraseña debe tener un mínimo de 6 (seis) caracteres.")]
        public string Password { get; set; }
        public int RoleID { get; set; } = 2;
    }
}
