using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RefactorThis.Domain.Models;

namespace RefactorThis.Data.Repositories
{
    public interface IProductOptionRepository
    {
        Task<IEnumerable<ProductOption>> GetAllProductOptionsByProductAsync(Guid aProductId);
        Task<ProductOption> GetProductOptionByDetailsAsync(Guid aProductOptionId);
        Task<ProductOption> AddProductOptionsAsync(ProductOption aProduct);
        Task<ProductOption> UpdateProductOptionsAsync(ProductOption aProduct);
        Task<bool> RemoveProductOptionsAsync(Guid aId);
    }
}