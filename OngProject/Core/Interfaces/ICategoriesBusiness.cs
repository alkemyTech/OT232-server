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
        Task<Response<PagedData<List<CategoryRequestDto>>>> GetAll(int Page = 1);
        Task<Category> GetById(int Id);
        Task<Response<bool>> Delete(int Id);
        Task<Response<bool>> Update(UpdateCategoryDto category, int Id);
        Task<int> CountElements();
    }
}
