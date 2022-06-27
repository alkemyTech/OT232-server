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
                Image = "Somosmas.jpg",

            });
            
            

        }
    }

    
}
