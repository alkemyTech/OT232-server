using OngProject.Core.Models.DTOs;
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

            foreach (var slide in listSlides)
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

        public static SlideDto toSlideDto(Slide slide)
        {
            if (slide == null)
                return null;

            var slideDto = new SlideDto
            {
                ImageURL = slide.ImageURL,
                Text = slide.Text,
                Order = slide.Order
            };
            return slideDto;
        }


        public static Slide UpdateToSlide(UpdateSlidesDto slideDto)
        {
            Slide slide = new Slide();

            slide.ImageURL = slideDto.ImageURL;
            slide.Text = slideDto.Text;
            slide.Order = slideDto.Order;
            slide.OrganizationID = slideDto.OrganizationId;

            return slide;
        }



        public static List<SlideOrganizationDto> ToSlideOrganizationDto(List<Slide> listSlides)
        {

            if (listSlides == null)
                return null;

            var slideDto = new List<SlideOrganizationDto>();

            foreach (var slide in listSlides)
            {
                slideDto.Add(
                new SlideOrganizationDto
                {

                    ImageURL = slide.ImageURL,
                    Text = slide.Text,
                    Order = slide.Order,
                    Organization = new OrganizationDto
                    {
                        Name = slide.Organization.Name,
                        Image = slide.Organization.Image,
                        Phone = slide.Organization.Phone,
                        Address = slide.Organization.Address,
                        WelcomeText = slide.Organization.WelcomeText,
                        AboutUsText = slide.Organization.AboutUsText,
                        LinkedinUrl = slide.Organization.LinkedinUrl,
                        FacebookUrl = slide.Organization.FacebookUrl,
                        InstagramUrl = slide.Organization.InstagramUrl
                        
                    }

                });

            }

            return slideDto;
        }

        public static Slide toDtoInsertSlide(InsertSlideDto insertSlideDto, string order)
        {
            if (insertSlideDto == null)
                return null;

            var slide = new Slide
            {
                ImageURL = insertSlideDto.ImageURL,
                Text = insertSlideDto.Text,
                Order = int.Parse(order),
                OrganizationID = insertSlideDto.OrganizationID
            };

            return slide;
        }

    }
}
