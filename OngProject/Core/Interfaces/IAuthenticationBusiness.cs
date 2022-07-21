using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using OngProject.Entities;

using System.Threading.Tasks;
using OngProject.Core.Models;

namespace OngProject.Core.Interfaces
{
    public interface IAuthenticationBusiness
    {
        Task<Response<RegisterRequestDto>> GetById(int Id);
        Task<bool> UserRegister(RegisterRequestDto userRegister);
        Task<List<User>> UserExists(LoginUserDto user);
        Task<LoginResponseDto> GetToken(LoginUserDto user);

    }
}
