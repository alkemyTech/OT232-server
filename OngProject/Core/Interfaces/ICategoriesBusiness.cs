using OngProject.Core.Models;
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
        Task<Response<bool>> Delete(int Id);
        Task<Response<bool>> Update(UpdateCategoryDto category, int Id);
    }
}
