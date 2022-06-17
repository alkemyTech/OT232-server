using Microsoft.EntityFrameworkCore;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class TestimonialsRepository : GenericRepository<Testimonials>
    {
        public TestimonialsRepository(DbContext context) : base(context)
        {
        }
    }
}
