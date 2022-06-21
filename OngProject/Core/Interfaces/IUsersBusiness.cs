using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    interface IUsersBusiness
    {
        List<Task> GetAll();
        Task GetById(int Id);
        Task Insert();
        Task Update();
        Task Delete(int Id);
    }
}
