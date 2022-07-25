using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class TestimonialMapper
    {
        public static Testimonial ToTestimonial(InsertTestimonialDto testimonialDto)
        {
            if (testimonialDto != null)
            {
                Testimonial testimonial = new()
                {
                    Content = testimonialDto.Content,
                    Name = testimonialDto.Name,
                    Image = testimonialDto.Image
                };

                return testimonial;
            }
            return null;
        }

        public static List<Testimonial> ToTestimonialsList(List<InsertTestimonialDto> testimonialDtos)
        {
            List<Testimonial> testimonials = new();

            if (testimonialDtos != null)
            {
                foreach (var t in testimonialDtos)
                {
                    testimonials.Add
                    (
                        new Testimonial
                        {
                            Content = t.Content,
                            Name = t.Name,
                            Image = t.Image
                        }
                    );
                }
                return testimonials;
            }
            return null;
        }

        public static List<TestimonialDto> ToTestimonialsDtoList(List<Testimonial> testimonial)
        {
            List<TestimonialDto> testimonialsdto = new();

            if (testimonial != null)
            {
                foreach (var t in testimonial)
                {
                    testimonialsdto.Add
                    (
                        new TestimonialDto
                        {
                            Content = t.Content,
                            Name = t.Name,
                            Image = t.Image
                        }
                    );
                }
                return testimonialsdto;
            }
            return null;

        }

        public static Testimonial UpdateToTestimonial(UpdateTestimonialDto testimonialDto, Testimonial model)
        {
            if (testimonialDto != null)
            {
                model.Name = testimonialDto.Name;
                model.Content = testimonialDto.Content;
                model.Image = testimonialDto.Image;
                return model;
            }
            return null;
        }
    }
}
