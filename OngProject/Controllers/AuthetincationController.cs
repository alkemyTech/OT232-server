using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Models.DTOs;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("auth")]
    [ApiController]

    public class AuthetincationController : ControllerBase
    {
        public static UserPasswordDto user = new UserPasswordDto();

        [HttpPost("register")]
        public IActionResult Register(RegisterRequestDto request)
        {
            CreateHashPass(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            user.User = request.Name;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok("Usuario Registrado");
        }

        //Encripta Contraseña
        private void CreateHashPass(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        //Desencripta Contraseña
        private bool VerifyHashPass(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
