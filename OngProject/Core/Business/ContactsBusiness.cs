using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ContactsBusiness : IContactsBusiness
    {
        public readonly IUnitOfWork _unitOfWork;

        public ContactsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Contact>> GetAll()
        {
            var contacts = new List<Contact>();
            var result = await _unitOfWork.ContactsRepository.GetAll();

            foreach (var o in result)
                contacts.Add(new Contact { Id= o.Id, Name = o.Name, Email = o.Email, Phone = o.Phone, Message = o.Message, LastModified = o.LastModified });

            return contacts;
        }

        public Task<Contact> GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert()
        {
            throw new System.NotImplementedException();
        }

        public Task<Contact> Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
