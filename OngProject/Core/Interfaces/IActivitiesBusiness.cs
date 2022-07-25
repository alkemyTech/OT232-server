using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IActivitiesBusiness
    {
        Task<Response<List<ActivitiesDto>>> GetAll();
        Task<Response<bool>> Insert(List<InsertActivityDto> activitiesDtos);
        Task<Response<bool>> Update(int Id, UpdateActivityDto activityDto);
        Task<Response<bool>> Delete(int id);
    }
}