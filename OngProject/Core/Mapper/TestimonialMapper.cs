using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class TestimonialMapper
    {
        public static Testimonial ToTestimonial(InsertTestimonialDto testimonialDto)
        {
            Testimonial testimonial = new()
            {
                Content = testimonialDto.Content,
                Name = testimonialDto.Name,
                Image = testimonialDto.Image
            };

            return testimonial;
        }

        public static List<Testimonial> ToTestimonialsList(List<InsertTestimonialDto> testimonialDtos)
        {
            List<Testimonial> testimonials = new();

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
    }
}
