using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;

namespace OngProject.DataAccess
{
    public static class SeedsNews
    {
        public static void SeedNews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasData(
                new News
                {
                    Id = 1,
                    IsDeleted = false,
                    Name = @"First News",
                    Description = @"This is the first News",
                    Image = @"This_is_the_first_News",
                    LastModified = DateTime.Now,
                },
                new News
                {
                    Id = 2,
                    IsDeleted = false,
                    Name = @"Second News",
                    Description = @"This is the second News",
                    Image = @"This_is_the_second_News",
                    LastModified = DateTime.Now,
                },
                new News
                {
                    Id = 3,
                    IsDeleted = false,
                    Name = @"Third News",
                    Description = @"This is the third News",
                    Image = @"This_is_the_third_News",
                    LastModified = DateTime.Now,
                },
                new News
                {
                    Id = 4,
                    IsDeleted = false,
                    Name = @"Quarter News",
                    Description = @"This is the quarter News",
                    Image = @"This_is_the_quarter_News",
                    LastModified = DateTime.Now,
                },
                 new News
                 {
                     Id = 5,
                     IsDeleted = false,
                     Name = @"Fifth News",
                     Description = @"This is the fifth News",
                     Image = @"This_is_the_fifth_News",
                     LastModified = DateTime.Now,
                 },
                 new News
                 {
                     Id = 6,
                     IsDeleted = false,
                     Name = @"Sixth News",
                     Description = @"This is the sixth News",
                     Image = @"This_is_the_sixth_News",
                     LastModified = DateTime.Now,
                 },
                 new News
                 {
                     Id = 7,
                     IsDeleted = false,
                     Name = @"Seventh News",
                     Description = @"This is the seventh News",
                     Image = @"This_is_the_seventh_News",
                     LastModified = DateTime.Now,
                 },
                 new News
                 {
                     Id = 8,
                     IsDeleted = false,
                     Name = @"Eighth News",
                     Description = @"This is the eighth News",
                     Image = @"This_is_the_eighth_News",
                     LastModified = DateTime.Now,
                 },
                 new News
                 {
                     Id = 9,
                     IsDeleted = false,
                     Name = @"Nineth News",
                     Description = @"This is the nineth News",
                     Image = @"This_is_the_nineth_News",
                     LastModified = DateTime.Now,
                 },
                 new News
                 {
                     Id = 10,
                     IsDeleted = false,
                     Name = @"Tenth News",
                     Description = @"This is the tenth News",
                     Image = @"This_is_the_tenth_News",
                     LastModified = DateTime.Now,
                 });
        }
    }
}
