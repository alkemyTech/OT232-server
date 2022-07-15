using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ISlidesBusiness
    {
        Task<Response<List<SlideDto>>> GetAll();

        Task<Response<SlideDto>> GetById(int id);

        Task<Response<bool>> Insert(InsertSlideDto slideDto);

        Task<Response<bool>> Update(UpdateSlidesDto slides, int Id);

        Task<Response<bool>> Delete(int Id);
    }
}
