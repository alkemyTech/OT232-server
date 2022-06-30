﻿using OngProject.Core.Interfaces;
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

        public Task<List<User>> GetAll()
        {
            throw new System.NotImplementedException();
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

        public Task Insert()
        {
            throw new System.NotImplementedException();
        }

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
