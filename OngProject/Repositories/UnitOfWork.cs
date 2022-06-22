using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private IGenericRepository<User> _userRepository;
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

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {

                    _userRepository = new GenericRepository<User>(_context);
                }
                return _userRepository;
            }
        }
    }
}

