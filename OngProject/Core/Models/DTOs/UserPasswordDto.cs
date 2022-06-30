using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class UserPasswordDto
    {
        public string User { get; set; } = string.Empty;
        public string PasswordEncrypted { get; set; }
    }
}
