using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IMembersBusiness
    {

        Task<Response<List<MemberDto>>> GetAll();

        Task GetById(int id);

        Task<Response<bool>> Insert(List<InsertMemberDto> memberDtos);

        Task Update();

        Task<Response<string>> Delete(int id);

    }
}
