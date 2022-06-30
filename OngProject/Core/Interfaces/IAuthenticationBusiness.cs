using OngProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IAuthenticationBusiness
    {
        Task<bool> UserRegister(RegisterRequestDto userRegister);
    }
}
