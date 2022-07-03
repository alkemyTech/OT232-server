using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public class CategoryMapper
    {
        public static Category ToCategory(CategoryRequestDto categoryDto)
        {
            Category category = new Category();
            category.Name = categoryDto.Name;
            return category;
        }
    }
}
