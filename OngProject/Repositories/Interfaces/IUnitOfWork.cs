using OngProject.Entities;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UsersRepository { get; }
        IGenericRepository<Category> CategoriesRepository { get; }
        IGenericRepository<News> NewsRepository { get; }
    }
}
