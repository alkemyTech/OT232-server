using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface INewsBusiness
    {
        Task Insert();
        List<Task> GetAll();
        Task GetById(int Id);
        Task Delete(int Id);
        Task Update();
    }
}
