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

        public async Task<bool> Delete(int Id)
        {
            T entity = await _context.Set<T>().FindAsync(Id);
            if(entity == null || entity.IsDeleted){
                return false;
            }   
            else{
                entity.IsDeleted = true;
                entity.LastModified = DateTime.Now;
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<T>> GetAll() => await _context.Set<T>().Where(x => !x.IsDeleted).ToListAsync();

        public async Task<T> GetById(int Id) => await _context.Set<T>().FindAsync(Id);

        public async Task<bool> Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> InsertRange(List<T> entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<T> Update(T entity)
        {
            var model = await _context.Set<T>().FindAsync(entity);
            if (model == null || model.IsDeleted == true)
            {
                return null;
            }
            else
            {
                _context.Entry(model).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
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
