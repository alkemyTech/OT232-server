using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IAuthenticationBusiness
    {
        Task<LoginResponseDto> GetToken(LoginUserDto user);
        Task<List<User>> UserExists(LoginUserDto user);
    }
}
