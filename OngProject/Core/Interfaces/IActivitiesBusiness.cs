using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IActivitiesBusiness
    {

        Task<Response<List<ActivitiesDto>>> GetAll();

        Task GetById(int id);

        Task<Response<bool>> Insert(List<InsertActivityDto> activitiesDtos);

        Task Update();

        Task<Response<string>> Delete(int id);

    }
}