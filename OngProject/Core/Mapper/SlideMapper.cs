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
            List<SlideDto> listSlideDto = new();

            if(listSlides != null)
            {
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
            return null;
        }

        public static SlideDto ToSlideDto(Slide slide)
        {
            if (slide != null)
            {
                var slideDto = new SlideDto
                {
                    ImageURL = slide.ImageURL,
                    Text = slide.Text,
                    Order = slide.Order
                };
                return slideDto;
            }
            return null;
        }

        public static Slide UpdateToSlide(UpdateSlidesDto slideDto)
        {
            if(slideDto != null)
            {
                Slide slide = new()
                {
                    ImageURL = slideDto.ImageURL,
                    Text = slideDto.Text,
                    Order = slideDto.Order,
                    OrganizationID = slideDto.OrganizationId
                };
                return slide;
            }
            return null;
        }

        public static List<SlideOrganizationDto> ToSlideOrganizationDto(List<Slide> listSlides)
        {
            var slideDto = new List<SlideOrganizationDto>();

            if (listSlides != null) 
            {
                foreach (var slide in listSlides)
                {
                    slideDto.Add
                    (
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
                        }
                    );
                }
                return slideDto;
            }
            return null;
        }

        public static Slide ToDtoInsertSlide(InsertSlideDto insertSlideDto, string order)
        {
            if (insertSlideDto != null) 
            {
                var slide = new Slide
                {
                    ImageURL = insertSlideDto.ImageURL,
                    Text = insertSlideDto.Text,
                    Order = int.Parse(order),
                    OrganizationID = insertSlideDto.OrganizationID
                };
                return slide;
            }
            return null;
        }
    }
}
