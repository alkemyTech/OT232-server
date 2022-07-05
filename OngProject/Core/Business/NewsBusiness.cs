using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class NewsBusiness : INewsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<News> Delete(int id)
        {
            var model = await _unitOfWork.NewsRepository.Delete(id);

            return model;
        }

        public List<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<NewsDto>> GetById(int Id)
        {
            var response = new Response<NewsDto>(NewsMapper.ToNewsDto(await _unitOfWork.NewsRepository.GetById(Id)));
            if (response.Data == null)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }
            return response;
        }

        public async Task<Response<bool>> Insert(NewsDto news)
        {
            throw new NotImplementedException();
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
