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
    public class MembersBusiness : IMembersBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        public MembersBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<Response<bool>> Delete(int Id)
        {
            var response = new Response<bool>(await _unitOfWork.MembersRepository.Delete(Id));
            if (!response.Data)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.Error;

            }
            return response;
        }

        public async Task<Response<PagedData<List<MemberDto>>>> GetAll(int pageNumber) 
        {
            var query = new QueryProperty<Member>(pageNumber, 10);
            var pgData = new PagedData<List<MemberDto>>(MemberMapper.ToMembersDtoList(await _unitOfWork.MembersRepository.GetAsync(query)), await CountElements(), pageNumber,10, "Members");
            var response = new Response<PagedData<List<MemberDto>>>(pgData);
            if (response.Data == null)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }

            return response;
        }

        public async Task<Response<bool>> Insert(List<InsertMemberDto> memberDtos) 
        {
            var response = new Response<bool>(await _unitOfWork.MembersRepository.InsertRange(MemberMapper.ToMemberList(memberDtos)));
            
            if (!response.Data) 
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }

            return response;
        }

        public async Task<Response<bool>> Update(UpdateMemberDto member, int Id)
        {
            var response = new Response<bool>(false);
            var find = await _unitOfWork.MembersRepository.GetById(Id);

            if (find == null)
            {
                response.Message = ResponseMessage.NotFoundOrDeleted;
                response.Succeeded = false;
                return response;
            }

            response.Data = await _unitOfWork.MembersRepository.Update(MemberMapper.UpdateToMember(member, find));
            return response;
        }

        public async Task<int> CountElements() => await _unitOfWork.MembersRepository.CountElements();
    }
}
