using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

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

        public static List<CategoryRequestDto> ToCategoryNameList(List<Category> categories)
        {
            List<CategoryRequestDto> categoriesDtos = new();

            foreach (var c in categories)
            {
                categoriesDtos.Add
                (
                    new CategoryRequestDto
                    {
                        Name = c.Name,
                    }
                );
            }

            return categoriesDtos;
        }
    }
}
