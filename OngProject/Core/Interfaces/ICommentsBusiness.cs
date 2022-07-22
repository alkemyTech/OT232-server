using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ICommentsBusiness
    {
        Task<Response<bool>> Insert(List<InsertCommentDto> commentDto);
        Task<Response<List<GetCommentDto>>> GetAll();
        Task<Response<string>> Delete(int Id);
        Task<Response<bool>> Update(UpdateCommentDto commentDto, int Id);
    }
}
