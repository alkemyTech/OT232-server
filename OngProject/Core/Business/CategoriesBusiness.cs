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

        public async Task<Response<List<CategoryRequestDto>>> GetAll() 
        {
            var response = new Response<List<CategoryRequestDto>>(CategoryMapper.ToCategoryNameList(await _unitOfWork.CategoriesRepository.GetAll()));
            if (response.Data == null)
            {
                response.Message = ResponseMessage.NotFoundOrDeleted;
                response.Succeeded = false;
            }
            return response;
        }
   
        public async Task<Response<Category>> GetById(int Id)
        {
            var response = new Response<Category>(await _unitOfWork.CategoriesRepository.GetById(Id));
            if (response.Data == null)
            {
                response.Message = ResponseMessage.NotFoundOrDeleted;
                response.Succeeded = false;
            }
            return response;
        }

        public async Task<Response<bool>> Insert(CategoryRequestDto dto) 
        {
            var response = new Response<bool>(await _unitOfWork.CategoriesRepository.Insert(CategoryMapper.ToCategory(dto)));
            if (!response.Data)
            {
                response.Message = ResponseMessage.NotFoundOrDeleted;
                response.Succeeded = false;
            }
            return response;
        }

        public async Task<Response<bool>> Update(UpdateCategoryDto dto, int Id)
        {
            var category = await _unitOfWork.CategoriesRepository.GetById(Id);
            var response = new Response<bool>(await _unitOfWork.CategoriesRepository.Update(CategoryMapper.UpdateToCategory(dto, category)));

            if (!response.Data)
            {
                response.Message = ResponseMessage.NotFoundOrDeleted;
                response.Succeeded = false;
            }
            return response;
        }
    }
}
