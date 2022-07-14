using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

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

        public static List<NewsDto> ToNewsDtoList(List<News> newsList) 
        {
            List<NewsDto> newsDtos = new();

            if (newsList != null) 
            {
                foreach (var n in newsList)
                    newsDtos.Add(new NewsDto
                    {
                        Name = n.Name,
                        Description = n.Description,
                        Image = n.Image
                    });
                return newsDtos;
            }

            return null;
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
        public static News UpdateToNews(UpdateToNewsDto newsDTO)
        {
            News news = new News();

            news.Name = newsDTO.Name;
            news.Description = newsDTO.Description;
            news.Image = newsDTO.Image;
            news.CategoryId = newsDTO.CategoryId;

            return news;
        }
    }
}
