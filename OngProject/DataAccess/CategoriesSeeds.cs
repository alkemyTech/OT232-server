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
                Name = "Programas Educativos Niños",
                Description = " Buscamos incrementar la capacidad intlectual, moral y efectiva de las personas de acuerdo" +
                " a la cultura y las normas de convivencia a la que pertenecen, con edades de entre 6 y 14 años ",
                Image = "Somosmas.jpg",

            },
            new Category
            {
                Id = 1,
                Name = "Programas Educativos Adolescentes",
                Description = " Buscamos incrementar la capacidad intlectual, moral y efectiva de las personas de acuerdo a " +
                "las necesidades que esten vivendo y sus carencias para adolescentes con edades de entre 14 a 18 años",
                Image = "Somosmas.jpg",

            },
            new Category
            {
                Id = 1,
                Name = "Programas Educativos Jovenes",
                Description = " Buscamos incrementar la capacidad intlectual, moral y efectiva de jovenes que esten gtransitando carreras terciarias" +
                "y/o ubiversitarias de edades de entre 18 y 35 años ",
                Image = "Somosmas.jpg",

            },
            new Category
            {
                Id = 1,
                Name = "Programas Educativos Adultos",
                Description = " Buscamos incrementar la concurrencia de adultos que no han termanado sus estudios para facilitarles " +
                "la insercion en la sociedad con mas herramientas ",
                Image = "Somosmas.jpg",

            },
            new Category
            {
                Id = 1,
                Name = "Programas Educativos",
                Description = " Buscamos incrementar la capacidad intlectual, moral y efectiva de las personas de acuerdo a la culturay las nor,as de convivencia a la que pertenecen ",
                Image = "Somosmas.jpg",

            });



        }
    }

    
}
