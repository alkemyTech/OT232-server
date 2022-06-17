using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    interface ITestimonialsBusiness
    {
        Task Insert();
        List<Task> GetAll();
        Task GetById(int Id);
        Task Delete(int Id);
        Task Update();
    }
}
