using Microsoft.AspNetCore.Http;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
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

        public async Task<Response<bool>> Delete(int Id)
        {

            var model = await _unitOfWork.NewsRepository.Delete(id);

            return null;

            var response = new Response<bool>(await _unitOfWork.NewsRepository.Delete(Id));
            if (!response.Data)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.NotFoundOrDeleted;
            }
            return response;
        }

        public async Task<Response<PagedData<List<NewsDto>>>> GetAll(int Page = 1)
        {
            var query = new QueryProperty<News>(Page, 10);
            var paged = new PagedData<List<NewsDto>>(NewsMapper.ToNewsDtoList(await _unitOfWork.NewsRepository.GetAsync(query)), await CountElements(), Page, 10);
            var response = new Response<PagedData<List<NewsDto>>>(paged);

            if (response.Data == null)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.NotFound;
                response.Errors = new string[] { "404" };
            }

            return response;
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

        public async Task<Response<bool>> Insert(InsertNewsDto news)
        {
            var resp = new Response<bool>(await _unitOfWork.NewsRepository.Insert(NewsMapper.InsertToNewsModel(news)));
            if (!resp.Data)
            {
                resp.Succeeded = false;
                resp.Message = ResponseMessage.UnexpectedErrors;
            }
            return resp;
        }


        public Task Update()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentDto>> GetComments(int newsId)
        {
            var news = await _unitOfWork.NewsRepository.GetById(newsId);
            if (news == null)
            {
                return null;
            }               
            var query = new QueryProperty<Comment>();
            query.Where = x => x.NewsID == newsId;
            var comments = await _unitOfWork.CommentsRepository.GetAsync(query);

            return comments.Select(x => x.CommentDto()).ToList();
        }

        public async Task<int> CountElements() => await _unitOfWork.NewsRepository.CountElements();
    }
}
