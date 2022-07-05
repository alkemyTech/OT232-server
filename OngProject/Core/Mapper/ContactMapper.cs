using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class ContactMapper
    {

        public static Contact ToContact(InsertContactDto contactDto)
        {
            Contact contact = new()
            {
                Name = contactDto.Name,
                Email = contactDto.Email,
                Phone = contactDto.Phone,
                Message = contactDto.Message
            };

            return contact;
        }


        public static List<Contact> ToContactList(List<InsertContactDto> contactDtos)
        {
            List<Contact> contacts = new();

            foreach (var c in contactDtos)
            {
                contacts.Add
                (
                    new Contact
                    {
                        Name = c.Name,
                        Email = c.Email,
                        Phone = c.Phone,
                        Message = c.Message
                    }
                );
            }

            return contacts;
        }
    }
}