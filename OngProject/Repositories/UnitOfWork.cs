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