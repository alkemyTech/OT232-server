
using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;

namespace OngProject.DataAccess
{
    public static class SlidesSeed
    {
        public static async void Seed(OngDbContext context)
        {
            await context.AddRangeAsync(
                new Slide
                {
                    Id = 1,
                    IsDeleted = false,
                    ImageURL = @"First Slide",
                    Text = @"This is the first Slide",
                    Order = 1,
                    LastModified = DateTime.Now,
                    OrganizationID = 1
                },
                new Slide
                {
                    Id = 2,
                    IsDeleted = false,
                    ImageURL = @"Second Slide",
                    Text = @"This is the Second Slide",
                    Order = 2,
                    LastModified = DateTime.Now,
                    OrganizationID = 1
                },
                new Slide
                {
                    Id = 3,
                    IsDeleted = false,
                    ImageURL = @"Third Slide",
                    Text = @"This is the Third Slide",
                    Order = 3,
                    LastModified = DateTime.Now,
                    OrganizationID = 2
                },
                new Slide
                {
                    Id = 4,
                    IsDeleted = false,
                    ImageURL = @"Fourth Slide",
                    Text = @"This is the Fourth Slide",
                    Order = 4,
                    LastModified = DateTime.Now,
                    OrganizationID = 2
                });
        }
    }
}
