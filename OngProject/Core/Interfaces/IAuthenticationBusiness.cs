using OngProject.Core.Models.DTOs;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IAuthenticationBusiness
    {
        Task<LoginResponseDto> GetToken(LoginUserDto user);
        Task<bool> UserExists(LoginUserDto user);
    }
}
