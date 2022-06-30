using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using OngProject.Entities;

using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IAuthenticationBusiness
    {

        Task<bool> UserRegister(RegisterRequestDto userRegister);
        Task<List<User>> UserExists(LoginUserDto user);
        Task<LoginResponseDto> GetToken(LoginUserDto user);

    }
}
