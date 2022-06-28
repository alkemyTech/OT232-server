using OngProject.Entities;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<News> NewsRepository { get; }
        IGenericRepository<User> UsersRepository { get; }
    }
}
