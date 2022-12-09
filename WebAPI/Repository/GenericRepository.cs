using WebAPI.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Data;

namespace WebAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseModel
    {
        protected DataContext _appContext;

        public GenericRepository(DataContext context) => _appContext = context;

        public async Task<int> CreateAsync(T entity)
        {
            await _appContext.Set<T>().AddAsync(entity);
            await _appContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(T entity)
        {
            _appContext.Set<T>().Remove(entity);
            await _appContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return (await _appContext.Set<T>().ToListAsync()).AsQueryable();
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> condition)
        {
            return (await _appContext.Set<T>().Where(condition).ToListAsync()).AsQueryable();
        }

        public async Task UpdateAsync(T entity)
        {
            _appContext.Set<T>().Update(entity);
            await _appContext.SaveChangesAsync();
        }

    }
}
