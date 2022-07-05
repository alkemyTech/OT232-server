﻿using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Mapper
{
    public static class SlideMapper
    {
        public static List<SlideDto> ToSlideDtoList(List<Slide> listSlides)
        {
           List<SlideDto> listSlideDto = new List<SlideDto>();

           foreach(var slide in listSlides)
           {
                var slideDto = new SlideDto
                {
                    ImageURL = slide.ImageURL,
                    Text = slide.Text,
                    Order = slide.Order
                };
                listSlideDto.Add(slideDto);
           }
           
            return listSlideDto;
        }
    }
}