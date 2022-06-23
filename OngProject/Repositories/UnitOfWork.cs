using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OngDbContext _context;
        public UnitOfWork(OngDbContext context)
        {
            _context = context;
        }
    }
}


        public IGenericRepository<News> NewsRepository
        {
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new GenericRepository<News>(_context);

                }
                return _newsRepository;

            }
        }

}


