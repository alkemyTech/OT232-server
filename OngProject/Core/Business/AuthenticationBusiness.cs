using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OngProject.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using OngProject.Repositories.Interfaces;

namespace OngProject.Core.Business
{
    public class AuthenticationBusiness : IAuthenticationBusiness
    {
        private readonly IUsersBusiness _usersBusiness;
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationBusiness(IUsersBusiness usersBusiness, IConfiguration config, IUnitOfWork unitOfWork)
        {
            _usersBusiness = usersBusiness;
            _config = config;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> UserExists(LoginUserDto user) => await _usersBusiness.GetAsync(user);

        public async Task<bool> UserRegister(RegisterRequestDto userRegister) => await _usersBusiness.Insert(userRegister);

        public async Task<LoginResponseDto> GetToken(LoginUserDto user)
        {
            List<Claim> authClaims = new();
            var userList = await _usersBusiness.GetAsync(user);
            User userProperties = new();

            foreach (var r in userList)
                userProperties = r;

            try
            {
                authClaims.Add(new Claim(type: "Id", userProperties.Id.ToString()));
                authClaims.Add(new Claim(ClaimTypes.Email, user.Email));
                authClaims.Add(new Claim(ClaimTypes.Role, userProperties.Roles.Name));
                authClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                var authSigingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    expires: DateTime.Now.AddHours(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigingKey, SecurityAlgorithms.HmacSha256)
                );

                return new LoginResponseDto
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ValidTo = token.ValidTo
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

