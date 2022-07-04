using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class CommentsBusiness : ICommentsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> Insert(List<InsertCommentDto> commentDtos)
        {
            var response = new Response<bool>(await _unitOfWork.CommentsRepository.InsertRange(CommentMapper.ToCommentsList(commentDtos)));

            if (!response.Data)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }
            return response;
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }

    }
}
