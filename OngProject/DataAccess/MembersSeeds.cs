using System;
using Microsoft.EntityFrameworkCore;
using OngProject.Entities;

namespace OngProject.DataAccess
{

    public static class MembersSeeds
    {
        public static void MembersSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(
            new Member
            {
                Id = 1,
                IsDeleted = false,
                Name = @"María Irola",
                FacebookUrl = @"Facebook/Maria-Irola",
                InstagramUrl = @"Instagram/Maria-Irola",
                LinkedinUrl = @"Linkein/Maria-Irola",
                Image = @"Maria-Irola.jpg",
                Description = @"​Fundadora,Voluntaria,Economista",
                LastModified = DateTime.Now,

            },
            new Member
            {
                Id = 2,
                IsDeleted = false,
                Name = @"Marita Gomez",
                FacebookUrl = @"Facebook/Marita-Gomez",
                InstagramUrl = @"Instagram/Marita-Gomez",
                LinkedinUrl = @"Linkein/Marita-Gomez",
                Image = @"Marita-Gomez.jpg",
                Description = @"​Fundadora,Nutricionista,voluntaria, especialista en nutricion infantil",
                LastModified = DateTime.Now,

            },
            new Member
            {
                Id = 3,
                IsDeleted = false,
                Name = @"Miriam Rodriguez",
                FacebookUrl = @"Facebook/Miriam-Rodriguez",
                InstagramUrl = @"Instagram/Miriam-Rodriguez",
                LinkedinUrl = @"Linkein/Miriam-Rodriguez",
                Image = @"Miriam-Rodriguez.jpg",
                Description = @"​Colaboradora,Terapista Ocupacional",
                LastModified = DateTime.Now,

            },
             new Member
             {
                 Id = 4,
                 IsDeleted = false,
                 Name = @"Cecilia Mendez",
                 FacebookUrl = @"Facebook/Cecilia-Mendez",
                 InstagramUrl = @"Instagram/Cecilia-Mendez",
                 LinkedinUrl = @"Linkein/Cecilia-Mendez",
                 Image = @"Cecilia-Mendez.jpg",
                 Description = @"Colaboradora,​Psicopedagoga",
                 LastModified = DateTime.Now,

             },
             new Member
             {
                 Id = 5,
                 IsDeleted = false,
                 Name = @"Mario Fuentes",
                 FacebookUrl = @"Facebook/Mario-Fuente",
                 InstagramUrl = @"Instagram/Mario-Fuente",
                 LinkedinUrl = @"Linkein/Mario-Fuente",
                 Image = @"Mario-Fuente.jpg",
                 Description = @"Colaborador,​Psicólogo",
                 LastModified = DateTime.Now,

             },
             new Member
             {
                 Id = 6,
                 IsDeleted = false,
                 Name = @"Rodrigo Fuente",
                 FacebookUrl = @"Facebook/Rodrigo-Fuente",
                 InstagramUrl = @"Instagram/Rodrigo-Fuente",
                 LinkedinUrl = @"Linkein/Rodrigo-Fuente",
                 Image = @"Rodrigo-Fuente.jpg",
                 Description = @"​Colaborador,Contador",
                 LastModified = DateTime.Now,

             },
             new Member
             {
                 Id = 7,
                 IsDeleted = false,
                 Name = @"Maria Garcia",
                 FacebookUrl = @"Facebook/Maria-Garcia",
                 InstagramUrl = @"Instagram/Maria-Garcia",
                 LinkedinUrl = @"Linkein/Maria-Garcia",
                 Image = @"Maria-Garcia.jpg",
                 Description = @"​Colaboradora,Profesora de Artes Dramáticas",
                 LastModified = DateTime.Now,

             },
              new Member
              {
                  Id = 8,
                  IsDeleted = false,
                  Name = @"Mario Fernandez",
                  FacebookUrl = @"Facebook/Mario-Fernandez",
                  InstagramUrl = @"Instagram/Mario-Fernandez",
                  LinkedinUrl = @"Linkein/Mario-Fernandez",
                  Image = @"Mario-Fernandez.jpg",
                  Description = @"Colaborador,Profesor de Educación Física​",
                  LastModified = DateTime.Now,

              });
             }


        }
    }
