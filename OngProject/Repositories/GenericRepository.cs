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
        private readonly OngDbContext _context;

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
            var entity = await _context.Set<T>().FindAsync(Id);

            return entity;
        }

        public Task<T> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
        public Task<List<T>> GetAsync(QueryProperty<T> query)
        {
            try
            {
                var source = ApplyQuery(query, _context.Set<T>().AsQueryable());
                return source.ToListAsync();
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        private static IQueryable<T> ApplyQuery(QueryProperty<T> query, IQueryable<T> source)
        {
            if (query is null)
                return source;

            if (query.Where is not null)
                source = source.Where(query.Where);

            foreach (var property in query.Includes)
                source = source.Include(property);
            
            if (query.Skip > 0)
                source = source.Skip(query.Skip);

            if (query.Take > 0)
                source = source.Take(query.Take);

            return source;
        }
    }
}
