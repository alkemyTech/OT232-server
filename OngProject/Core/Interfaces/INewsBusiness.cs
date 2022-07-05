using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Interfaces
{
    public interface INewsBusiness
    {
        Task Insert();
        List<Task> GetAll();
        Task GetById(int Id);
        Task<News> Delete(int Id);
        Task Update();

        Task<List<CommentDto>> GetComments(int newsId);
    }
}
