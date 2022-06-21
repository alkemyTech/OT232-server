using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        private IGenericRepository<Activity> _activitiesRepository;
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
