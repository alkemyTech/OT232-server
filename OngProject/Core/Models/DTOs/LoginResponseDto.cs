using System;

namespace OngProject.Core.Models.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }

    }
}
