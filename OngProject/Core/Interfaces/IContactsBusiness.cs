using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IContactsBusiness
    {
        Task<Response<bool>> Insert(InsertContactDto contactDto);
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int Id);
        Task Delete(int Id);
        Task<Contact> Update();
    }
}
