using OngProject.Core.Helper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Mapper
{
    public class UserMapper
    {
        public static User ToUser(RegisterRequestDto registerDto)
        {
            User user = new User();
            user.FirstName = registerDto.FirstName;
            user.LastName = registerDto.LastName;
            user.Email = registerDto.Email;
            user.Password = registerDto.Password;
            user.RoleID = registerDto.RoleID;
            return user;
        }
        
        public static LoginUserDto ToLoginUser(RegisterRequestDto registerDto)
        {
            LoginUserDto user = new LoginUserDto { 
                Email = registerDto.Email,
                Password = registerDto.Password
            };
            return user;
        }

        public static List<UserDto> ConvertUserDto(List<User> users)
        {
            var listaUserDto = new List<UserDto>();
            foreach (var user in users)
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

        public static User ToUpdateUserDto(UpdateUserDto userDto, User user)
        {
            user.Password = CryptographyHelper.CreateHashPass(userDto.Password);
            return user;
        }
    }
}
