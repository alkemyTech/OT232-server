using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class ContactMapper
    {
        public static List<Contact> ToContactList(List<InsertContactDto> contactDtos)
        {
            List<Contact> contact = new();

            foreach (var m in contactDtos)
            {
                contact.Add
                (
                    new Contact
                    {
                        Name = m.Name,
                        Email = m.Email,
                        Phone = m.Phone,
                        Message = m.Message
                    }
                );
            }

            return contact;
        }

        public static List<ContactsDto> ToContactsDtoList(List<Contact> contacts)
        {
            List<ContactsDto> contactDtos = new();

            foreach (var m in contacts)
            {
                contactDtos.Add
                (
                    new ContactsDto
                    {
                        Name = m.Name,
                        Email = m.Email,
                        Phone = m.Phone,
                        Message = m.Message
                    }
                );
            }

            return contactDtos;
        }
    }
}