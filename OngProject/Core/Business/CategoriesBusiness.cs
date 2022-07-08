using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
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

        public async Task<Response<bool>> Delete(int Id)
        {
            var response = new Response<bool>(await _unitOfWork.CategoriesRepository.Delete(Id));
            if (!response.Data)
            {
                response.Message = ResponseMessage.NotFoundOrDeleted;
                response.Succeeded = false;
            }
            return response;
        }

        public async Task<List<CategoryRequestDto>> GetAll() => CategoryMapper.ToCategoryNameList(await _unitOfWork.CategoriesRepository.GetAll());
   
        public async Task<Category> GetById(int Id)
        {
            return await _unitOfWork.CategoriesRepository.GetById(Id);
        }

        public async Task<bool> Insert(CategoryRequestDto dto) => await _unitOfWork.CategoriesRepository.Insert(CategoryMapper.ToCategory(dto));

        public async Task<Response<bool>> Update(UpdateCategoryDto category, int Id)
        {
            var response = new Response<bool>();

            var find = await _unitOfWork.CategoriesRepository.GetById(Id);
            
            if (find != null)
            {
                response.Data = await _unitOfWork.CategoriesRepository.Update(CategoryMapper.UpdateToCategory(category));

                return response;
                
            }

            response.Message = ResponseMessage.NotFoundOrDeleted;
            response.Succeeded = false;

            return response;
        }
    }
}
