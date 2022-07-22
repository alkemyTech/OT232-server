using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IContactsBusiness
    {

        Task<Response<List<ContactsDto>>> GetAll();


        Task<Response<bool>> Insert(List<InsertContactDto> contactsDtos);


        Task<Response<bool>> Delete(int id);

    }
}