using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
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

        public async Task<Response<PagedData<List<CategoryRequestDto>>>> GetAll(int Page = 1)
        {
            var query = new QueryProperty<Category>(Page, 10);
            var paged = new PagedData<List<CategoryRequestDto>>(CategoryMapper.ToCategoryNameList(await _unitOfWork.CategoriesRepository.GetAsync(query)), await CountElements(), Page, 10, "Categories");
            var response = new Response<PagedData<List<CategoryRequestDto>>>(paged);

            if (response.Data == null)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.NotFound;
                response.Errors = new string[] { "404" };
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
            var response = new Response<bool>(false);
            var category = await _unitOfWork.CategoriesRepository.GetById(Id);

            if (category == null) 
            { 
                response.Message = ResponseMessage.NotFoundOrDeleted;
                response.Succeeded = false;
                return response;
            }

            response.Data = await _unitOfWork.CategoriesRepository.Update(CategoryMapper.UpdateToCategory(dto, category));
            return response;
        }

        public async Task<int> CountElements() => await _unitOfWork.CategoriesRepository.CountElements();
    }
}
