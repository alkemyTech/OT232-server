using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    interface IRolesBusiness
    {
        Task Insert();
        List<Task> GetAll();
        Task GetById(int Id);
        Task Delete(int Id);
        Task Update();
    }
}
