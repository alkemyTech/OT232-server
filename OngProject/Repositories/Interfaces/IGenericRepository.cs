using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Insert(T entity);
        List<Task<T>> GetAll();
        Task<T> GetById(int Id);
        Task<T> Delete(int Id);
        Task<T> Update(T entity);
    }
}
