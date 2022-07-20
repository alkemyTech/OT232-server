using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;

namespace OngProject.DataAccess
{
    public static class OrganizationsSeed
    {
        public static async void Seed(OngDbContext context)
        {
            await context.AddRangeAsync(
            new Organization
            {
                Id = 1,
                IsDeleted = false,
                Name = @"Somos Más",
                Image = "somosmas.jpg",
                Address = "Somos Más",
                Email = "somosfundacionmas@gmail.com",
                Phone = "1160112988",
                WelcomeText = "¡Bienvenido a Somos Más!",
                AboutUsText = "Desde 1997 en Somos Más trabajamos con los chicos y chicas, mamás y papás, abuelos y vecinos del barrio La Cava generando procesos de crecimiento y de inserción social.",
                FacebookUrl = "https://facebook.com/Somos_Mas",
                InstagramUrl = "https://instagram.com/SomosMas",
                LinkedinUrl = "https://linkedin.com/in/SomosMas",
                LastModified = DateTime.UtcNow
            },
            new Organization
            {
                Id = 2,
                IsDeleted = false,
                Name = @"Somos Más2",
                Image = "somosmas2.jpg",
                Address = "Somos Más2",
                Email = "somosfundacionmas2@gmail.com",
                Phone = "1160112900",
                WelcomeText = "¡Bienvenido a Somos Más2!",
                AboutUsText = "Desde 1997 en Somos Más2 trabajamos con los chicos y chicas, mamás y papás, abuelos y vecinos del barrio La Cava generando procesos de crecimiento y de inserción social.",
                FacebookUrl = "https://facebook.com/Somos_Mas2",
                InstagramUrl = "https://instagram.com/SomosMas2",
                LinkedinUrl = "https://linkedin.com/in/SomosMas2",
                LastModified = DateTime.UtcNow
            });
        }
    }
}
