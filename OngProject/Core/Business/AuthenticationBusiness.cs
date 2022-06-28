using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class AuthenticationBusiness : IAuthenticationBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersBusiness _usersBusiness;
        private readonly IConfiguration _config;

        public AuthenticationBusiness(IUnitOfWork unitOfWork, IUsersBusiness usersBusiness, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _usersBusiness = usersBusiness;
            _config = config;
        }

        public async Task<bool> UserExists(LoginUserDto user) 
        {
            var result = await _usersBusiness.GetAsync(user);

            if(result == null)
                return false;

            return true;
        }

        public async Task<LoginResponseDto> GetToken(LoginUserDto user)
        {
            ClaimsIdentity authClaims = new ClaimsIdentity();
            authClaims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            authClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var authSigingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));

            var token = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                expires: DateTime.Now.AddHours(1),
                claims: (IEnumerable<Claim>)authClaims,
                signingCredentials: new SigningCredentials(authSigingKey, SecurityAlgorithms.HmacSha256)
            );

            return new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo
            };
        }
    }
}
