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
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class TestimonialsBusiness : ITestimonialsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestimonialsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Delete(int Id)
        {
            var response = new Response<bool>(await _unitOfWork.TestimonialsRepository.Delete(Id));
            if (!response.Data)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.Error;

            }
            return response;
        }

        public async Task<Response<PagedData<List<TestimonialDto>>>> GetAll(int Page = 1)
        {
            var query = new QueryProperty<Testimonial>(Page, 10);
            var paged = new PagedData<List<TestimonialDto>>(TestimonialMapper.ToListTestimonial
                (await _unitOfWork.TestimonialsRepository.GetAsync(query)), await CountElements(), Page, 10, "News");
            var response = new Response<PagedData<List<TestimonialDto>>>(paged);

            if (response.Data == null)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.NotFound;
                response.Errors = new string[] { "404" };
            }

            return response;
        }


        public Task GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> Insert(List<InsertTestimonialDto> testimonialsDtos)
        {
            var response = new Response<bool>(await _unitOfWork.TestimonialsRepository.InsertRange(TestimonialMapper.ToTestimonialsList(testimonialsDtos)));

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

        public async Task<int> CountElements() => await _unitOfWork.TestimonialsRepository.CountElements();
    }
}
