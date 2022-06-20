using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class CategoriesRepository : GenericRepository<Categories>, ICategoriesRepository
    {
        private readonly DbContext _context;
        public CategoriesRepository(DbContext context) : base(context)
        {
            _context = context;
        }


        public Task<Categories> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Task<Categories>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Categories> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Categories> Insert(Categories entity)
        {
            throw new NotImplementedException();
        }

        public Task<Categories> Update(Categories entity)
        {
            throw new NotImplementedException();
        }
    }
}
