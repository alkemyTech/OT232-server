using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ITestimonialsBusiness
    {
        Task<Response<bool>> Insert(List<InsertTestimonialDto> testimonialsDto);
        Task<Response<PagedData<List<TestimonialDto>>>> GetAll(int Page = 1);
        Task<Response<bool>> Delete(int Id);
        Task<int> CountElements();
        Task<Response<bool>> Update(UpdateTestimonialDto testimonial, int Id);
    }
}
