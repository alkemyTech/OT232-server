using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class UsersBusiness : IUsersBusiness
    {

        private readonly IUnitOfWork _unitOfWork;

        public UsersBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Insert(RegisterRequestDto dto) => await _unitOfWork.UsersRepository.Insert(UserMapper.ToUser(dto));

        public Task Update()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<UserDto>> GetAll()
        {
            var listUserDto = new List<UserDto>();
            var users = await _unitOfWork.UsersRepository.GetAll();
            if(users != null)
            {
                listUserDto = ConvertUserToDto.ConvertUserDto(users);
            }
            return listUserDto;
        }
    }
}
