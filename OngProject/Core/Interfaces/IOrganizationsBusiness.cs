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

        public Task Insert();

        public Task Update();

        public Task Delete();

        Task<List<SlideOrganizationDto>> GetSlides(int Id);
    }
}
