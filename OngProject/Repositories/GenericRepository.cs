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

        public List<Task<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(T entity)
        {
            entity.IsDeleted = false;
            entity.LastModified = DateTime.UtcNow;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
