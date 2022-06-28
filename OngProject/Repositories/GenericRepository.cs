using Microsoft.EntityFrameworkCore;
using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private OngDbContext _context;

        public GenericRepository(OngDbContext context)
        {
            _context = context;
        }

        public Task<T> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll()
        {
            var source = _context.Set<T>().Where(x => !x.IsDeleted);
            return await source.ToListAsync();
        }

        public Task<T> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
