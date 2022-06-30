using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
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
                dtos.Add(new OrganizationDto{ Name = o.Name, Address = o.Address, Image = o.Image, Phone = o.Phone });

            return dtos;
        }

        public Task<Organization> GetById(int id)
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
