using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RefactorThis.Data.Repositories._Framework
{
    public interface IGenericRepository<T> 
    {
        Task<T> AddAsync(T aEntity);
        Task<T> UpdateAsync(T aEntity);
        Task DeleteAsync(Guid aId);
        Task<T> GetAsync(Guid aId);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        Task<int> SaveChangesAsync();
    }
}