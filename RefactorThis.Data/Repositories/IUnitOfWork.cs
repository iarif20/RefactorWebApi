using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RefactorThis.Data.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IProductOptionRepository ProductOptionRepository { get; }
        Task<int> SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private ProductContext _context;

        public UnitOfWork(ProductContext aContext)
        {
            this._context = aContext;
        }

        private IProductRepository _productRepository;
        public IProductRepository ProductRepository
        {
            get
            {
                
                if (_productRepository == null)
                {
                    _productRepository =  new ProductRepository(_context);
                }

                return _productRepository;
            }
        }

        private IProductOptionRepository _productOptionRepository;

        public IProductOptionRepository ProductOptionRepository
        {
            get
            {
                if (_productOptionRepository == null)
                {
                    _productOptionRepository = new ProductOptionRepository(_context);
                }
                return _productOptionRepository;
            }
        }

        public async Task<int> SaveChanges()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}