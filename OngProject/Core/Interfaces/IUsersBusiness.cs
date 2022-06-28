using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IUsersBusiness
    {
        Task<List<User>> GetAll();
        Task<List<User>> GetAsync(LoginUserDto userDto);
        Task GetById(int Id);
        Task Insert();
        Task Update();
        Task Delete(int Id);
    }
}
