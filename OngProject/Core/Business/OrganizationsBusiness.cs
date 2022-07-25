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
    public class OrganizationsBusiness : IOrganizationsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrganizationsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Response<List<OrganizationDto>>> GetAll()
        {
            var response = new Response<List<OrganizationDto>> (OrganizationMapper.ToOrganizationsDtoList(await _unitOfWork.OrganizationsRepository.GetAll()));

            if (response == null)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }
            return response;
        }

        public async Task<Response<List<SlideOrganizationDto>>> GetSlides(int Id)
        {
            var response = new Response<List<SlideOrganizationDto>>(null);
            var query = new QueryProperty<Slide>(1, 1)
            {
                Where = x => x.OrganizationID == Id,
                OrderBy = x => x.Order
            };
            var organization = await _unitOfWork.OrganizationsRepository.GetById(Id);

            if (organization == null) 
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
                return response;
            }

            response.Data = SlideMapper.ToSlideOrganizationDto(await _unitOfWork.SlidesRepository.GetAsync(query));
            return response;
        }

        public async Task<Response<bool>> Insert(List<InsertOrganizationDto> orgDtos)
        {
            var response = new Response<bool>(await _unitOfWork.OrganizationsRepository.InsertRange(OrganizationMapper.ToOrganizationList(orgDtos)));

            if (!response.Data)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }

            return response;
        }
        public async Task<Response<bool>> Update(int Id, UpdateOrganizationDto organization)
        {
            var resp = new Response<bool>(false);
            var model = await _unitOfWork.OrganizationsRepository.GetById(Id);

            if (model == null) 
            { 
                resp.Succeeded = false;
                resp.Message = ResponseMessage.UnexpectedErrors;
                return resp;
            }

            resp.Data = await _unitOfWork.OrganizationsRepository.Update(OrganizationMapper.MixModels(organization, model));
            return resp;
        }

    }
}
