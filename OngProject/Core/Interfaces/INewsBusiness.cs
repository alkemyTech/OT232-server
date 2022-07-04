using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Interfaces
{
    public interface INewsBusiness
    {
        Task<Response<bool>> Insert(NewsDto news);
        List<Task> GetAll();
        Task GetById(int Id);
        Task<News> Delete(int Id);
        Task Update();
    }
}
