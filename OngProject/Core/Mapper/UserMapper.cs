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
    }
}
