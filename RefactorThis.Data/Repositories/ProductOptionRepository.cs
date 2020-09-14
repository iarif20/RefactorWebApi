using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RefactorThis.Data.Repositories._Framework;
using RefactorThis.Domain.Models;

namespace RefactorThis.Data.Repositories
{
    public class ProductOptionRepository : GenericRepository<ProductOption>, IProductOptionRepository
    {
        public ProductOptionRepository(ProductContext aContext):base(aContext)
        {
            
        }
        public async Task<IEnumerable<ProductOption>> GetAllProductOptionsByProductAsync(Guid aProductOptionId)
        {
            try
            {
                var result = Find(e => e.Id.Equals(aProductOptionId));
                return await result.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ProductOption> GetProductOptionByDetailsAsync( Guid aProductOptionId)
        {
            try
            {
                var result = Find(e => e.Id.Equals(aProductOptionId));
                    
                return await result.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ProductOption> AddProductOptionsAsync(ProductOption aOption)
        {
            try
            {
                await AddAsync(aOption);
                return aOption;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ProductOption> UpdateProductOptionsAsync(ProductOption aOption)
        {
            try
            {
                await UpdateAsync(aOption);
                return aOption;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        

       

     

       

        public async Task<bool> RemoveProductOptionsAsync(Guid aProductOptionId)
        {
            try
            {
                await DeleteAsync(aProductOptionId);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}