﻿using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.DataAccess;
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

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insert(List<InsertTestimonialDto> testimonialsDtos) => await _unitOfWork.TestimonialsRepository.InsertRange(TestimonialMapper.ToTestimonialsList(testimonialsDtos));

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
