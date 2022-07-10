using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ContactsBusiness : IContactsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<Response<string>> Delete(int id)
        {
            var response = new Response<string>();
            var contact = await _unitOfWork.ContactsRepository.GetById(id);
            if (contact == null)
            {
                throw new Exception("Contact does not exist.");
            }
            if (contact.IsDeleted == true || contact.Id != id)
            {
                throw new Exception("Contact does not exist or deleted.");
            }
            if (contact != null)
            {
                await _unitOfWork.ContactsRepository.Delete(id);

                return new Response<string>("Success", message: "Entity Deleted");
            }
            else
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
                return response;
            }
        }

        public async Task<Response<List<ContactsDto>>> GetAll()
        {
            var response = new Response<List<ContactsDto>>(ContactMapper.ToContactsDtoList(await _unitOfWork.ContactsRepository.GetAll()));

            if (response.Data == null)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }

            return response;
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> Insert(List<InsertContactDto> contactsDtos)
        {
            var response = new Response<bool>(await _unitOfWork.ContactsRepository.InsertRange(ContactMapper.ToContactList(contactsDtos)));

            if (!response.Data)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }

            return response;
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}