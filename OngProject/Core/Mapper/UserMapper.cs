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
            if (registerDto != null)
            {
                User user = new();
                user.FirstName = registerDto.FirstName;
                user.LastName = registerDto.LastName;
                user.Email = registerDto.Email;
                user.Password = registerDto.Password;
                user.RoleID = registerDto.RoleID;
                return user;
            }
            return null;
        }
        
        public static LoginUserDto ToLoginUser(RegisterRequestDto registerDto)
        {
            if (registerDto != null)
            {
                LoginUserDto user = new LoginUserDto
                {
                    Email = registerDto.Email,
                    Password = registerDto.Password
                };
                return user;
            }
            return null;
        }
        
        public static RegisterRequestDto ToRegisterRequest(User user)
        {
            if (user != null)
            {
                RegisterRequestDto dto = new()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = CryptographyHelper.DecryptHashPass(user.Password),
                    RoleID = user.RoleID
                };
                return dto;
            }
            return null;
        }

        public static User ToUpdateUserDto(UpdateUserDto userDto, User user)
        {
            if (user != null)
            {
                user.Password = CryptographyHelper.CreateHashPass(userDto.Password);
                return user;
            }
            return null;
        }
        public static UserDto ToUserDto(User user)
        {
            if (user != null)
            {
                UserDto userDto = new()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Photo = user.Photo
                };
                return userDto;
            }
            return null;
        }

        public static List<UserDto> ToUserDtoList(List<User> users)
        {
            var userDtoList = new List<UserDto>();

            if (users != null)
            {
                foreach (var user in users)
                {
                    var userDto = new UserDto
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Photo = user.Photo
                    };
                    userDtoList.Add(userDto);
                }
                return userDtoList;
            }
            return null;
        }
    }
}
