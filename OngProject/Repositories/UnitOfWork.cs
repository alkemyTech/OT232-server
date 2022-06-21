using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private IGenericRepository<News> _newsRepository;
        private IGenericRepository<Category> _categoriesRepository;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IGenericRepository<News> NewsRepository
        {
            get { if (_newsRepository == null) {
                    _newsRepository = new GenericRepository<News>(_context); 

               } return _newsRepository;

            } 
        }

        public IGenericRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoriesRepository == null)
                {
                    _categoriesRepository = new GenericRepository<Category>(_context);

                }
                return _categoriesRepository;
            }
        }
    }
}
