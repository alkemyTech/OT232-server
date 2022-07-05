using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class SlidesBusiness : ISlidesBusiness
    {

        private readonly IUnitOfWork _unitOfWork;
        public SlidesBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<SlideDto>>> GetAll()
        {
            var slides = await _unitOfWork.SlidesRepository.GetAll();
            var n = SlideMapper.ToSlideDtoList(slides);
            var response = new Response<List<SlideDto>>(n);

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

        public Task Insert()
        {
            throw new NotImplementedException();
        }


        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
