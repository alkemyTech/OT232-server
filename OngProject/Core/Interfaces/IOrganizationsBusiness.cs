using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IOrganizationsBusiness
    {

        public Task<List<OrganizationDto>> GetAll();
        public Task<Organization> GetById(int id);
        Task<Response<bool>> Insert(InsertOrganizationDto organization);
        public Task Update();
        public Task Delete();
    }
}
