using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            T entity = _context.Set<T>().Find(Id);
            entity.IsDeleted = true;
            entity.LastModified = DateTime.Now;
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public List<Task<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int Id)
        {

            //var query = _context.Set<T>().AsNoTracking()
            //.Where(t => t.Id == Id && t.IsDeleted == false);
            // return query.FirstOrDefaultAsync();
            var findGeneric = await _context.Set<T>().FindAsync(Id);

            return findGeneric;

            T entity = _context.Set<T>().Find(Id);

            return Task.FromResult(entity);

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
