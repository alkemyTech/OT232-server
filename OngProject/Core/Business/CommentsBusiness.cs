
using Microsoft.AspNetCore.Http;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class CommentsBusiness : ICommentsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommentsBusiness(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<Response<string>> Delete(int id)
        {
            {
                var response = new Response<string>();
                var comments = await _unitOfWork.CommentsRepository.GetById(id);
                if (comments == null)
                {
                    throw new Exception("Comment does not exist.");
                }
                if (comments.IsDeleted == true || comments.Id != id)
                {
                    throw new Exception("Comment does not exist or deleted.");
                }

                var role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
                var user = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == "Id").Value);
                if (role == "Administrador" || user == comments.UserId)
                {
                    await _unitOfWork.CommentsRepository.Delete(id);
                    
                    return new Response<string>("Success", message: "Entity Deleted");
                }
                else
                {
                    response.Data = "Error - 403";
                    response.Succeeded = false;
                    response.Message = "You do not have permission to modify it.";
                    return response;
                }
            }
               
        }

        public async Task<Response<List<GetCommentDto>>> GetAll()
        {
            var query = new QueryProperty<Comment>();
            query.OrderBy = x => x.LastModified;
            var response = new Response<List<GetCommentDto>>(CommentMapper.
                               ToOrderedDtoList(await _unitOfWork.CommentsRepository.
                               GetAsync(query)));
            if(response.Data is null)
            {
                response.Message = ResponseMessage.Error;
                response.Succeeded = false;
                response.Errors = new string[] { "Error - 500" };
            }
            return response;
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
