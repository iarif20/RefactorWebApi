using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RefactorThis.Data.Repositories._Framework;
using RefactorThis.Domain.Models;

namespace RefactorThis.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext aContext) : base(aContext)
        {
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                return await Context.Set<Product>().Include(aX=>aX.ProductOptions).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Product> AddProductAsync(Product aProduct)
        {
            try
            {
                await AddAsync(aProduct);
                return aProduct;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Product>> GetProductAsync(string aProductName)
        {
            try
            {
                var result = Find(e => e.Name.Equals(aProductName)).Include(a => a.ProductOptions);
                return await result.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            try
            {
                var result =   await GetAllAsync();
                return result.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Product> GetProductAsync(Guid aProductId)
        {
            try
            {
                var result = Find(e => e.Id.Equals(aProductId)).Include(a => a.ProductOptions);
                return await result.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Product> UpdateProductAsync(Product aProduct)
        {
            try
            {
                await UpdateAsync(aProduct);
                return aProduct;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> RemoveProductAsync(Guid aProductId)
        {
            try
            {
                await DeleteAsync(aProductId);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}