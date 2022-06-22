using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IActivitiesBusiness
    {
        Task Insert();
        List<Task> GetAll();
        Task GetById();
        Task Delete(int Id);
        Task Update();
    }
}
