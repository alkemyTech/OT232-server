using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;

namespace OngProject.DataAccess
{
    public static class ContactsSeed
    {
        public static async void Seed(OngDbContext context)
        {
            await context.AddRangeAsync(
            new Contact
            {
                Id = 1,
                IsDeleted = false,
                Name = @"First Contact",
                Email = @"firstcontact@example.com",
                Phone = "1111111111",
                Message = @"This is the first contact",
                LastModified = DateTime.Now,
            },
            new Contact
            {
                Id = 2,
                IsDeleted = false,
                Name = @"Second Contact",
                Email = @"secondcontact@example.com",
                Phone = "1111111112",
                Message = @"This is the Second contact",
                LastModified = DateTime.Now,
            });
        }
    }
}
