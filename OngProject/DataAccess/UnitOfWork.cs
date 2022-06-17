using OngProject.Repositories;

namespace OngProject.DataAccess
{
    public class UnitOfWork
    {
        private TestimonialsRepository _testimonialsRepository;
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public TestimonialsRepository TestimonialsRepository 
        {
            get 
            {
                if(_testimonialsRepository == null)
                    _testimonialsRepository = new TestimonialsRepository(_context);
                
                return _testimonialsRepository;
            }
        }    
    }
}
