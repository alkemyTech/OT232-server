using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        public UsersRepository(DbContext context) : base(context)
        {
        }
    }
}
