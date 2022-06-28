using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private readonly OngDbContext _context;
        public IGenericRepository<News> _newsRepository;
        public IGenericRepository<Activity> _activitiesRepository;
        
        public UnitOfWork(OngDbContext context)
        {
            _context = context;
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
        public IGenericRepository<Activity> ActivitiesRepository
        {
            get
            {
                if (_activitiesRepository == null)
                {
                    _activitiesRepository = new GenericRepository<Activity>(_context);

                }
                return _activitiesRepository;

            }

        }

    }
}


