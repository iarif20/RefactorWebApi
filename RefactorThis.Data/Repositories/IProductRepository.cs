using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefactorThis.Domain.Models;

namespace RefactorThis.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(Product aProduct);
        Task<List<Product>> GetProductAsync(string aProductName);
        Task<Product> GetProductAsync(Guid aProductId);
        Task<Product> UpdateProductAsync(Product aProduct);
        Task<bool> RemoveProductAsync(Guid aProductId);
        Task<List<Product>> GetAllProductAsync();
    }
}