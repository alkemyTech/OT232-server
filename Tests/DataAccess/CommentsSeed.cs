using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.DataAccess
{
    public static class CommentsSeed
    {
        public static async void Seed(OngDbContext context)
        {
            await context.AddRangeAsync(
            new Comment
            {
                Id = 1,
                UserId = 1,
                Body = "Las ONG son agrupaciones de gente que se reúnen para tomar acción solidaria.Me parece positivo.",
                NewsID = 1,
                LastModified = DateTime.Now
            },
            new Comment
            {
                Id = 2,
                UserId = 2,
                Body = "Las ONG son , por tanto, reflejo del compromiso de la sociedad civil con la resolución de esos problemas",
                NewsID = 2,
                LastModified = DateTime.Now
            },
            new Comment
            {
                Id = 3,
                UserId = 1,
                Body = "Por supuesto institucionalmente, pero también en lo económico, en el análisis que hacen de los problemas, en sus diagnósticos, en la elaboración de su misión, de sus prioridades, en sus relaciones.",
                NewsID = 3,
                LastModified = DateTime.Now
            },
            new Comment
            {
                Id = 4,
                UserId = 2,
                Body = "Un estudio comparativo desarrollado por la Universidad de Johns Hopkins en 22 países, con datos de 1995 demuestra claramente la importancia de la iniciativa social.  Esta investigación descubre que el sector mueve en estos 22 países ",
                NewsID = 2,
                LastModified = DateTime.Now
            });
        }
    }
}
