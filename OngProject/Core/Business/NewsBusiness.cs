using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
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

        public async Task<News> Delete(int id)
        {
            var model = await _unitOfWork.NewsRepository.Delete(id);

            return model;
        }

        public List<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetById(int Id)
        {
            return _unitOfWork.NewsRepository.GetById(Id);
        }

        public Task Insert()
        {
            throw new NotImplementedException();
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

    }
}
