using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;

namespace OngProject.DataAccess
{
    public static class RolesSeed
    {
        public static async void Seed(OngDbContext context)
        {
            await context.AddRangeAsync(
            new Roles
            {
                Id = 1,
                IsDeleted = false,
                Name = @"Administrador",
                Description = "Administrator Role",
                LastModified = DateTime.UtcNow
            },
            new Roles
            {
                Id = 2,
                IsDeleted = false,
                Name = @"Estándar",
                Description = "Standard Role",
                LastModified = DateTime.UtcNow
            });
        }
    }
}
