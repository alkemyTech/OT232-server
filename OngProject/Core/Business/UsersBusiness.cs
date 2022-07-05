using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
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

        public async Task<Response<bool>> Delete(int Id)
        {
            try
            {
                var response = new Response<bool>(await _unitOfWork.UsersRepository.Delete(Id));
                response.Message = ResponseMessage.Success;
                return response;

            }
            catch (Exception ex)
            {
                var response = new Response<bool>(false,false);
                response.Message = ex.Message;
                return response;

            }

        }

        public async Task<List<User>> GetAsync(LoginUserDto userDto)
        {
            var query = new QueryProperty<User>(1, 1);

            query.Where = x => (x.Email == userDto.Email) && (x.Password == userDto.Password); 
            query.Includes.Add(x => x.Roles);

            return await _unitOfWork.UsersRepository.GetAsync(query);
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
                listUserDto = ConvertUserToDto.ConvertUserDto(users);

            return listUserDto;
        }
    }
}
