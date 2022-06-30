using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IActivitiesBusiness
    {
        Task Insert();
        List<Task> GetAll();
        Task<Activity> GetById(int Id);
        Task Delete(int Id);
        Task<Activity> Update(Activity model, UpdateActivityDto activity); 
    }
}
