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
        Task GetById(int Id);
        Task Delete(int Id);
        Task Update(Activity model, UpdateActivityDto activity);
        
    }
}
