using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IMembersBusiness
    {

        Task<Response<PagedData<List<MemberDto>>>> GetAll(int pageNumber);

        Task<Response<bool>> Insert(List<InsertMemberDto> memberDtos);

        Task<Response<bool>> Update(UpdateMemberDto member, int Id);

        Task<Response<bool>> Delete(int Id);

    }
}
