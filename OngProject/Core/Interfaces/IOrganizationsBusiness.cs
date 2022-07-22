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

        Task<Response<List<OrganizationDto>>> GetAll();
        Task<Response<bool>> Insert(List<InsertOrganizationDto> orgDtos);
        Task<Response<bool>> Update(int Id, UpdateOrganizationDto organization);
        Task<Response<List<SlideOrganizationDto>>> GetSlides(int Id);

    }
}
