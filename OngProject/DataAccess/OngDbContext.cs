using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.DataAccess
{
    public class OngDbContext : DbContext
    {
        public OngDbContext(DbContextOptions<OngDbContext> options) : base(options)
        {

        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Slide> Slide { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.TestimonialsSeed();
            modelBuilder.ActivitiesSeed();
            modelBuilder.MembersSeed();
            modelBuilder.CategoriesSeeds();
            modelBuilder.SeedNews();

        }

    }

}
