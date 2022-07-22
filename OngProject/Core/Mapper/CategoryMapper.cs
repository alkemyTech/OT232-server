using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class CategoryMapper
    {
        public static Category ToCategory(CategoryRequestDto categoryDto)
        {
            if (categoryDto != null)
            {
                Category category = new()
                {
                    Name = categoryDto.Name
                };
                return category;
            }
            return null;
        }

        public static List<CategoryRequestDto> ToCategoryNameList(List<Category> categories)
        {
            List<CategoryRequestDto> categoriesDtos = new();

            if (categories != null)
            {
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
            return null;
        }

        public static Category UpdateToCategory(UpdateCategoryDto categoryDto)
        { 
            if (categoryDto != null)
            {
                Category category = new()
                {
                    Name = categoryDto.Name,
                    Description = categoryDto.Description,
                    Image = categoryDto.Image
                };

                return category;
            }
            return null;
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
