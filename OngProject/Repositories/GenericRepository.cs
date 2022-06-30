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
        private readonly OngDbContext _context;

        public GenericRepository(OngDbContext context)
        {
            _context = context;
        }

        public async Task<T> Delete(int Id)
        {
            T entity = await _context.Set<T>().FindAsync(Id);
            if(entity == null || entity.IsDeleted == true)
            {
                return null;
            }
            else
            {
                entity.IsDeleted = true;
                entity.LastModified = DateTime.Now;
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return await Task.FromResult(entity);
            }
           
        }

        public async Task<List<T>> GetAll()
        {
            var source = _context.Set<T>().Where(x => !x.IsDeleted);
            return await source.ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            var entity = await _context.Set<T>().FindAsync(Id);
            return entity;

        }

        public async Task<bool> Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> Update(T entity)
        {
            var model = await _context.Set<T>().FindAsync(entity);
            if(model == null || model.IsDeleted== true)
            {
                return null;
            }
            else
            {
                _context.Entry(model).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return  entity;
            }

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
