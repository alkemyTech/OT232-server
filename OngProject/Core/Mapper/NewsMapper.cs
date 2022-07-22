using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public static class NewsMapper
    {
        public static NewsDto ToNewsDto(News news)
        {
            if (news != null) { 
                var dto = new NewsDto
                {
                    Description = news.Description,
                    Image = news.Image,
                    Name = news.Name
                };
                return dto;
            }
            return null;
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
            if (dto != null)
            {
                var model = new News
                {
                    Description = dto.Description,
                    Image = dto.Image,
                    Name = dto.Name
                };
                return model;
            }
            return null;
        }

        public static News InsertToNewsModel(InsertNewsDto dto)
        {
            if (dto != null)
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
            return null;
        }

        public static News UpdateToNews(UpdateToNewsDto newsDTO)
        {
            if (newsDTO != null)
            {
                News news = new()
                {
                    Name = newsDTO.Name,
                    Description = newsDTO.Description,
                    Image = newsDTO.Image,
                    CategoryId = newsDTO.CategoryId
                };
                return news;
            }
            return null;
        }
    }
}
