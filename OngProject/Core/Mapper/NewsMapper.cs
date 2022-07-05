using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class NewsMapper
    {
        public static NewsDto ToNewsDto(News news)
        {
            var dto = new NewsDto
            {
                Description = news.Description,
                Image = news.Image,
                Name = news.Name
            };    

            return dto; 
        }
        public static News ToNewsModel(NewsDto dto) 
        {
            var model = new News
            {
                Description = dto.Description,
                Image = dto.Image,
                Name = dto.Name
            };
            return model;
        }
        public static News InsertToNewsModel(InsertNewsDto dto)
        {
            var model = new News
            {
                Description = dto.Description,
                Image = dto.Image,
                Name = dto.Name,
                CategoryId = dto.CategoryId
            };
            return model;
        }
    }
}
