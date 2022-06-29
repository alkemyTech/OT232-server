using OngProject.Core.Interfaces;
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

        public Task GetAll()
          {
            var query = new QueryProperty<Organization>(1, 1);
            query.Where = x => (x.Name == userDto.Name); 
            query.Where = x => (x.Image == userDto.Name); 
            query.Where = x => (x.Phone == userDto.Name); 
            query.Where = x => (x.Address == userDto.Name); 
            query.Includes.Add(x => x.Organization);

            var result = await _unitOfWork.OrganizationRepository.GetAsync(query);

            return result;
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
