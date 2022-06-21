using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
    {
        private readonly DbContext _context;
        public CategoriesRepository(DbContext context) : base(context)
        {
            _context = context;
        }


        public Task<Category> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Task<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
