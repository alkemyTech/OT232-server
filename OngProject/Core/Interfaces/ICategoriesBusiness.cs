using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ICategoriesBusiness
    {
        Task Insert();
        Task<List<Category>> GetAll();
        Task<Category> GetById(int Id);
        Task Delete(int Id);
        Task Update();

    }
}
