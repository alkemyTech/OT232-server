using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class TestimonialsRepository : GenericRepository<Testimonials>, ITestimonialsRepository
    {
        public TestimonialsRepository(DbContext context) : base(context)
        {
        }
    }
}
