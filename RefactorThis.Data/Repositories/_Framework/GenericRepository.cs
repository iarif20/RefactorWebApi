using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RefactorThis.Data.Repositories._Framework
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ProductContext Context;

        protected GenericRepository(ProductContext aContext)
        {
            Context = aContext;
        }
        public virtual async Task<T> AddAsync(T aEntity)
        {
            if (aEntity == null) throw new NoNullAllowedException($"{nameof(AddAsync)} Entity is null");
            try
            {
                await Context.AddAsync(aEntity);
                return aEntity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<T> UpdateAsync(T aEntity)
        {
            if (aEntity == null) throw new NoNullAllowedException($"{nameof(UpdateAsync)} Entity is null");
            try
            {
                await Task.Run(() => Context.Update(aEntity));
                return aEntity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task DeleteAsync(Guid aId)
        {
            try
            {
                T record = Context.Find<T>(aId);
                if(record==null) throw new Exception("Record doesn't exists");

                await Task.Run(() => Context.Remove(record));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<T> GetAsync(Guid aId)
        {
            try
            {
                return await Context.FindAsync<T>(aId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await Context.Set<T>().AsQueryable().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> aPredicate)
        {
            try
            { 
                var query =  Context.Set<T>().AsQueryable().Where(aPredicate);
                return query;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}