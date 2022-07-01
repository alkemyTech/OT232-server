using Microsoft.EntityFrameworkCore;
using OngProject.Core.Helper;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.DataAccess
{
    public static class UsersSeeds
    {
        public static void UsersSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "Maria",
                LastName = "Irola",
                Email = "mariaIrola22@user.com",
                Password = CryptographyHelper.CreateHashPass("maria_478"),
                Photo = "mariaIrola.jpg",
                RoleID = 1
            },
            new User
            {
                Id = 2,
                FirstName = "Marita",
                LastName = "Gomez",
                Email = "marita_Gomez2022@user.com",
                Password = CryptographyHelper.CreateHashPass("marita_245"),
                Photo = "marita.jpg",
                RoleID = 1
            },
            new User
            {
                Id = 3,
                FirstName = "Myriam",
                LastName = "Rodriguez",
                Email = "miriamRodri659@user.com",
                Password = CryptographyHelper.CreateHashPass("myriam_245"),
                Photo = "myriam.jpg",
                RoleID = 1
            },

             new User
             {
                 Id = 4,
                 FirstName = "Cecilia",
                 LastName = "Mendez",
                 Email = "cecilamendez_21@hotmail.com",
                 Password = CryptographyHelper.CreateHashPass("Cauyt_2022"),
                 Photo = "ceciliamendez.jpg",
                 RoleID = 1
             },

             new User
             {
                 Id = 5,
                 FirstName = "Juan",
                 LastName = "Fuentes",
                 Email = "juan125_Fuentes@gmail.com",
                 Password = CryptographyHelper.CreateHashPass("Fuentes.Jui14"),
                 Photo = "juanfuentes.jpg",
                 RoleID = 1
             },

             new User
             {
                 Id = 6,
                 FirstName = "Gabriela",
                 LastName = "Corrado",
                 Email = "gabrielajcorrado@gmail.com",
                 Password = CryptographyHelper.CreateHashPass("G478_posicion"),
                 Photo = "gabrielIurt25.jpg",
                 RoleID = 1
             },

              new User
              {
                  Id = 7,
                  FirstName = "Margarita",
                  LastName = "Gimenez",
                  Email = "gimenez_margarita25@gmail.com",
                  Password = CryptographyHelper.CreateHashPass("mendez_742"),
                  Photo = "imageMargarita.jpg",
                  RoleID = 1
              },

              new User
              {
                  Id = 8,
                  FirstName = "David",
                  LastName = "Campos",
                  Email = "davidwaltercampos@gmail.com",
                  Password = CryptographyHelper.CreateHashPass("mendez_742"),
                  Photo = "fotodavid.jpg",
                  RoleID = 1
              },

            new User
            {
                Id = 9,
                FirstName = "Walter",
                LastName = "Paz",
                Email = "walter_AlejandroPaz@gmail.com",
                Password = CryptographyHelper.CreateHashPass("mendez_742"),
                Photo = "particularfoto.jpg",
                RoleID = 1
            },

            new User
            {
                Id = 10,
                FirstName = "Sergio",
                LastName = "Aguilar",
                Email = "sergio_aguilar@gmail.com",
                Password = CryptographyHelper.CreateHashPass("patriSergio12"),
                Photo = "particularfoto.jpg",
                RoleID = 1
            },

            new User
            {
                Id = 11,
                FirstName = "Carolina",
                LastName = "Cano",
                Email = "cano_aguilar@gmail.com",
                Password = CryptographyHelper.CreateHashPass("Carytl45"),
                Photo = "cary.jpg",
                RoleID = 2
            },
            new User
            {
                Id = 12,
                FirstName = "Isaias",
                LastName = "Muragua",
                Email = "muraguaIsaias54@gmail.com",
                Password = CryptographyHelper.CreateHashPass("PorCasaMur"),
                Photo = "fotoisaias.jpg",
                RoleID = 2
            },

            new User
            {
                Id = 13,
                FirstName = "Javier",
                LastName = "Isaurralde",
                Email = "isaurralde478@gmail.com",
                Password = CryptographyHelper.CreateHashPass("PepitaLos789"),
                Photo = "fotitojavier.jpg",
                RoleID = 2
            },

            new User
            {
                Id = 14,
                FirstName = "Jose",
                LastName = "Salvatierra",
                Email = "salvatierragini@gmail.com",
                Password = CryptographyHelper.CreateHashPass("loli_71"),
                Photo = "salavatierra.jpg",
                RoleID = 2
            },
            new User
            {
                Id = 15,
                FirstName = "Monica",
                LastName = "Vasquez",
                Email = "vasquez45monigi@gmail.com",
                Password = CryptographyHelper.CreateHashPass("GranFER2022"),
                Photo = "monigi.jpg",
                RoleID = 2
            },
            new User
            {
                Id = 16,
                FirstName = "Maria",
                LastName = "Carrizo",
                Email = "maricarrizo@hotmail.com",
                Password = CryptographyHelper.CreateHashPass("juegoTermi12"),
                Photo = "carrizofoto.jpg",
                RoleID = 2
            },
            new User
            {
                Id = 17,
                FirstName = "Luisa",
                LastName = "villagra",
                Email = "luisakuu@gmail.com",
                Password = CryptographyHelper.CreateHashPass("hugo2022_"),
                Photo = "luisa.jpg",
                RoleID = 2
            },
            new User
            {
                Id = 18,
                FirstName = "Oscar",
                LastName = "Abud ",
                Email = "abudgoscar@gmail.com",
                Password = CryptographyHelper.CreateHashPass("pamelita_78"),
                Photo = "oscarAbud.jpg",
                RoleID = 2
            },
            new User
            {
                Id = 19,
                FirstName = "Jessica",
                LastName = "Urtiaga",
                Email = "urtiagali@hotmail.com",
                Password = CryptographyHelper.CreateHashPass("panchisHUy"),
                Photo = "jessica.jpg",
                RoleID = 2
            },
            new User
            {
                Id = 20,
                FirstName = "Irma",
                LastName = "campos",
                Email = "coride@gmail.com",
                Password = CryptographyHelper.CreateHashPass("pipatyu12"),
                Photo = "fotosirma.jpg",
                RoleID = 2
            });
        }
    }
}
