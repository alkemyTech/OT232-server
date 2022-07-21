using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IUsersBusiness
    {

        Task<List<User>> GetAsync(LoginUserDto userDto);
        Task<List<UserDto>> GetAll();
        Task<Response<RegisterRequestDto>> GetById(int Id);
        Task<bool> Insert(RegisterRequestDto dto);
        Task<Response<bool>> Update(UpdateUserDto userDto, int Id);
        Task<Response<bool>> Delete(int Id);
    }
}
