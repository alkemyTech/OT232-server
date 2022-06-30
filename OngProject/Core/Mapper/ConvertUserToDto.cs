using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Mapper
{
    public static class ConvertUserToDto
    {
        public static List<UserDto> ConvertUserDto(List<User> users)
        {
            var listaUserDto = new List<UserDto>();
            foreach(var user in users)
            {
                var userDto = new UserDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Photo = user.Photo
                };
                listaUserDto.Add(userDto);
            }
            return listaUserDto;
        }
    }
}
