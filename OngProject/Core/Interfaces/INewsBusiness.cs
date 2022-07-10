using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface INewsBusiness
    {
        Task<Response<bool>> Insert(InsertNewsDto news);
        Task<Response<PagedData<List<NewsDto>>>> GetAll(int Page = 1);
        Task<Response<NewsDto>> GetById(int Id); 
        Task<Response<bool>> Delete(int Id);
        Task<int> CountElements();
        Task Update();

        Task<List<CommentDto>> GetComments(int newsId);
    }
}
