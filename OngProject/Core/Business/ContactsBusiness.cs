﻿using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ContactsBusiness : IContactsBusiness
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        public ContactsBusiness(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
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

        public async Task<Response<bool>> Insert(InsertContactDto contactDtos)
        {
            var response = new Response<bool>(await _unitOfWork.ContactsRepository.Insert(ContactMapper.ToContact(contactDtos)));

            if (!response.Data)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }

            await _emailSender.SendWelcomeEmailAsync( contactDtos.Email , "!");

            return response;
        }

        public Task<Contact> Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
