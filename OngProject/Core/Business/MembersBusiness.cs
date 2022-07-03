using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
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
        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<MemberDto>>> GetAll() 
        {
            var response = new Response<List<MemberDto>>(MemberMapper.ToMembersDtoList(await _unitOfWork.MembersRepository.GetAll()));

            if (response.Data == null)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }

            return response;
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
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

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
