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
            var response = new Response<bool>(await _unitOfWork.UsersRepository.Delete(Id));
            response.Message = ResponseMessage.Success;
            if(!response.Data)
            {
                response.Message = ResponseMessage.NotFoundOrDeleted;
                response.Succeeded = false;
            }
            return response;
        }

        public async Task<List<User>> GetAsync(LoginUserDto userDto)
        {
            var query = new QueryProperty<User>(1, 1);

            query.Where = x => (x.Email == userDto.Email) && (x.Password == userDto.Password); 
            query.Includes.Add(x => x.Roles);

            return await _unitOfWork.UsersRepository.GetAsync(query);
        }

        public async Task<Response<RegisterRequestDto>> GetById(int Id)
        {
            var response = new Response<RegisterRequestDto>(UserMapper.ToRegisterRequest(await _unitOfWork.UsersRepository.GetById(Id)));

            if (response == null)
            {
                response.Succeeded = false;
                response.Errors = new string[] { "Error - 404" };
                response.Message = ResponseMessage.NotFound;
            }
            return response;
        }

        public async Task<bool> Insert(RegisterRequestDto dto) => await _unitOfWork.UsersRepository.Insert(UserMapper.ToUser(dto));

        public async Task<Response<bool>> Update(UpdateUserDto userDto, int Id)
        {
            var response = new Response<bool>();
            var user = await _unitOfWork.UsersRepository.GetById(Id);

            if (user != null)
            {
                var users = UserMapper.ToUpdateUserDto(userDto, user);
                response.Data = await _unitOfWork.UsersRepository.Update(users);
                return response;
            }

            response.Succeeded = false;
            response.Errors = new string[] { "Error - 404" };
            response.Message = ResponseMessage.NotFound;

            return response;
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
