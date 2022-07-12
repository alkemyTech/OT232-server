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

        public static Category UpdateToCategory(UpdateCategoryDto categoryDto)
        {
            Category category = new Category();

            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            category.Image = categoryDto.Image;

            return category;
        }

        public static Category UpdateToCategory(UpdateCategoryDto dto, Category category)
        {
            if (category != null)
            {
                category.Description = dto.Description;
                category.Name = dto.Name;
                category.Image = dto.Image;
                return category;
            }
            return null;
        }
    }
}
