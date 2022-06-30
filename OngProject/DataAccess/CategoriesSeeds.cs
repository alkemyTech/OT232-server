using Microsoft.EntityFrameworkCore;
using OngProject.Entities;

namespace OngProject.DataAccess
{
    public static class CategoriesSeeds
    {
        
        public static void CategoriesSeed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Programas Educativos",
                Description = " Buscamos incrementar la capacidad intlectual, moral y efectiva de las personas de acuerdo a la culturay las nor,as de convivencia a la que pertenecen ",
                Image = "Somosmas.jpg"
            },
            new Category
            {
                Id = 2,
                Name = "Programas Educativos",
                Description = " Buscamos incrementar la capacidad intlectual, moral y efectiva de las personas de acuerdo a la culturay las nor,as de convivencia a la que pertenecen ",
                Image = "Somosmas.jpg"
            },
            new Category
            {
                Id = ,
                Name = "Programas Educativos Adolescentes",
                Description = " Buscamos incrementar la capacidad efectiva y de vinculos con los pares para " +
                "una mejor autonomia y trabjo grupal",
                Image = "Somosmas.jpg"
            },
            new Category
            {
                Id = 4,
                Name = "Programas Educativos Jovenes",
                Description = " se pretnde crecimiento de habilidades, capacidades y nuevas herramientas para que logren un desempeño " +
                "con mayor eficiencia ",
                Image = "Somosmas.jpg"
            },
            new Category
            {
                Id = 5,
                Name = "Programas Educativos Adulto",
                Description = " Buscamos incrementar la capacidad y habilidades para un mejor desempeño dentro de la sociedad" +
                "y que logren mas productividad ",
                Image = "Somosmas.jpg"
            });





        }
    }

    
}
