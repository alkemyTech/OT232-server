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
        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrganizationDto>> GetAll() 
        {
            var dtos = new List<OrganizationDto>();
            var result = await _unitOfWork.OrganizationsRepository.GetAll();

            foreach (var o in result)
                dtos.Add(new OrganizationDto{ Name = o.Name, Address = o.Address, Image = o.Image, Phone = o.Phone, WelcomeText = o.WelcomeText, AboutUsText = o.AboutUsText, LinkedinUrl = o.LinkedinUrl, FacebookUrl = o.FacebookUrl, InstagramUrl = o.InstagramUrl });

            return dtos;
        }

        public async Task<List<SlideOrganizationDto>> GetSlides(int Id)
        {
            var organization = await _unitOfWork.OrganizationsRepository.GetById(Id);
            if (organization == null)
            {
                return null;
            }
            var query = new QueryProperty<Slide>();
            query.Where = x => x.OrganizationID == Id;
            query.OrderBy = x => x.Order;
            var slides = await _unitOfWork.SlidesRepository.GetAsync(query);

            return SlideMapper.ToSlideOrganizationDto(slides);
        }

        public Task<Organization> GetById(int id)
        {
            throw new NotImplementedException();
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
            var model = await _unitOfWork.OrganizationsRepository.GetById(Id);
           
            var resp = new Response<bool>(await _unitOfWork.OrganizationsRepository.Update(OrganizationMapper.MixModels(organization, model)));
            if (!resp.Data)
            {
                resp.Succeeded = false;
                resp.Message = ResponseMessage.UnexpectedErrors;
            }
            return resp;
        }

    }
}
