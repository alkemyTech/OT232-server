using System;
using Microsoft.EntityFrameworkCore;
using OngProject.Entities;

namespace OngProject.DataAccess
{
    public static class TestimonialsSeed
    {
        public static async void Seed(OngDbContext context)
        {
            await context.AddRangeAsync(
                new Testimonial
                {
                    Id = 1,
                    IsDeleted = false,
                    LastModified = DateTime.Now,
                    Name = @"Nosotros",
                    Image = @"nosotros.jpg",
                    Content = @"Desde 1997 en Somos Mas trabajamos con los chicos y chicas,mamas y papas, abuelos y vecinos del barrio La Cava generando procesos de crecimiento y de insercion social,Uniendo las manos de todas las familias, las que viven en el barrio y las que viven fuera de el, es que podemos pensar,crear y garantizar estos procesos. Somos una asociacion civil sin fines de lucro que se creo en 1998 con la intencion de dar alimento a las familias del barrio. Con el tiempo fuimos involucrandonos con la comunidad y agrandando y mejorar nuestra capacidad de trabajo. Hoy somos un centro comunitario que acompaña a mas de 700 personas a traves de las areas de : Educacion,deportes,primera infancia,salud,alimentacion y trabajo social.",

                },
                new Testimonial
                {
                    Id = 2,
                    IsDeleted = false,
                    LastModified = DateTime.Now,
                    Name = @"Vision",
                    Image = @"vision.jpg",
                    Content = @"Mejorar la calidad de vida de niños y familias en situacion de vulnerabilidad en el barrio La Cava,otorgando un cambio de rumbo en cada individuo a traves de la educacion,salud,trabajo,deporte,responsabilidad y compromiso",
                },
                new Testimonial
                {
                    Id = 3,
                    IsDeleted = false,
                    LastModified = DateTime.Now,
                    Name = @"Mision",
                    Image = @"mision.jpg",
                    Content = @"Trabajar articuladamente con los distintos aspectos de la vida de las familias, generando espacios de desarrollo personal y familiar, brindando herramientas que logren mejorar la calidad de vida a traves de su propio esfuerzo",
                },
                new Testimonial
                {
                    Id = 4,
                    IsDeleted = false,
                    LastModified = DateTime.Now,
                    Name = @"Maria Irola",
                    Image = @"mariaIrola.jpg",
                    Content = @"Presidenta Maria estudio economia y se especializo en economia para el desarrollo. Comenzo como voluntaria en la fundacion y fue quien promovio el crecimiento y la organizacion de la institucion acompañando la transformacion de un simple comedor barrial al centro comunitario de atencion integral que es hoy en dia",
                },
                new Testimonial
                {
                    Id = 5,
                    IsDeleted = false,
                    LastModified = DateTime.Now,
                    Name = @"Marita Gomez",
                    Image = @"maritaGomez.jpg",
                    Content = @"Fundadora Marita estudio la carrera de nutricion y se especializo en nutricion infantil. Toda la vida fue voluntaria en distintos espacios en el barrio hasta que decidio abrir un comedor propio.Comenzo trabajando con 5 familias y culmino su trabajo transformando Somos Mas en la organizacion que es hoy",
                }
                );
        }
    }
}
