using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    interface IActivitiesBusiness
    {
        Task Insert();
        List<Task> GetAll();
        Task GetById();
        Task Delete(int Id);
        Task Update();
    }
}
