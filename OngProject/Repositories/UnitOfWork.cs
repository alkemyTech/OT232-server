using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private IGenericRepository<Roles> _rolesRepository;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
    }

            public IGenericRepository<Roles> RolesRepository
        {
            get
            {
                if (_rolesRepository == null)
                {

                    _rolesRepository = new GenericRepository<Roles>(_context);
                }
                return _rolesRepository;
            }
        }
    }
}
}
