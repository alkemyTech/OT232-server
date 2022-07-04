using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ITestimonialsBusiness
    {
        Task<Response<bool>> Insert(List<InsertTestimonialDto> testimonialsDto);
        List<Task> GetAll();
        Task GetById(int Id);
        Task Delete(int Id);
        Task Update();
    }
}
