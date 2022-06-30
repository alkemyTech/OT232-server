using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class AuthenticationBusiness : IAuthenticationBusiness
    {
        private readonly IUsersBusiness _usersBusiness;

        public AuthenticationBusiness(IUsersBusiness usersBusiness)
        {
            _usersBusiness = usersBusiness;
        }

        public async Task<bool> UserRegister(RegisterRequestDto userRegister) => await _usersBusiness.Insert(userRegister);

    }
}
