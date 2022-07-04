using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ICategoriesBusiness
    {
        Task<bool> Insert(CategoryRequestDto categoryAdd);
        Task<List<CategoryRequestDto>> GetAll();
        Task<Category> GetById(int Id);
        Task Delete(int Id);
        Task Update();
    }
}
