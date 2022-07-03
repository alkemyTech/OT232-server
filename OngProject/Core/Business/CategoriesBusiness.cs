using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class CategoriesBusiness : ICategoriesBusiness
    {
        public readonly IUnitOfWork _unitOfWork;

        public CategoriesBusiness (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Category>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Category> GetById(int Id)
        {
            return await _unitOfWork.CategoriesRepository.GetById(Id);
        }

        public async Task<bool> Insert(CategoryRequestDto dto) => await _unitOfWork.CategoriesRepository.Insert(CategoryMapper.ToCategory(dto));
        public Task Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
