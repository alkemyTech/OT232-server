using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Repositories.Interfaces
{
    interface IActivitiesBusiness
    {
        Task Insert();
        List<Task>GetAll();
        Task GetById();
        Task Delete(int Id);
        Task Update();
    }
}
