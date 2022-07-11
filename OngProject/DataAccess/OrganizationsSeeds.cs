using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;

namespace OngProject.DataAccess
{
    public static class OrganizationsSeeds
    {
        public static void OrganizationsSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>().HasData(
            new Organization
            {
                Id = 1,
                IsDeleted = false,
                Name = @"Somos Más",
                Image = "somosmas.jpg",
                Address = "Somos Más",
                Email = "somosfundacionmas@gmail.com",
                Phone = 1160112988,
                WelcomeText = "¡Bienvenido a Somos Más!",
                AboutUsText = "Desde 1997 en Somos Más trabajamos con los chicos y chicas, mamás y papás, abuelos y vecinos del barrio La Cava generando procesos de crecimiento y de inserción social.",
                FacebookUrl = "https://facebook.com/Somos_Mas",
                InstagramUrl = "https://instagram.com/SomosMas",
                LinkedinUrl = "https://linkedin.com/in/SomosMas",
                LastModified = DateTime.UtcNow
            });
        }
    }
}
