using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OngDbContext _context;
        public IGenericRepository<News> _newsRepository;
        public IGenericRepository<User> _usersRepository;
        public IGenericRepository<Category> _categoryRepository;

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

        public IGenericRepository<User> UsersRepository
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new GenericRepository<User>(_context);

                }
                return _usersRepository;
            }
        }

        public IGenericRepository<Category> CategoriesRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new GenericRepository<Category>(_context);

                }
                return _categoryRepository;
            }
        }


    }
}


