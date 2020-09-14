using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RefactorThis.Service.Framework;
using RefactorThis.Service.Services.Product.Dtos;
using IUnitOfWork = RefactorThis.Data.Repositories.IUnitOfWork;

namespace RefactorThis.Service.Services.Product
{
    public class ProductService : ApplicationService, IProductService
    {
        private readonly IUnitOfWork UnitOfWork;

        public ProductService(IUnitOfWork aUnitOfWork)
        {
            UnitOfWork = aUnitOfWork;
        }
        public async Task<AddProductOutputDto> AddProductAsync(AddProductInputDto aParams)
        {
            var output = new AddProductOutputDto();
            try
            {
                var item = new Domain.Models.Product
                {
                    Name = aParams.Name,
                    Price = aParams.Price,
                    DeliveryPrice = aParams.DeliveryPrice,
                    Description = aParams.Description,
                    ProductOptions = Mapper.Map<List<Domain.Models.ProductOption>>(aParams.ProductOptions)
                };
                Domain.Models.Product product = await UnitOfWork.ProductRepository.AddProductAsync(item);
                await UnitOfWork.SaveChanges();
                output = Mapper.Map<AddProductOutputDto>(product);
            }
            catch (Exception e)
            {
                output.ResultErrors.Messages.Add(e.Message);
            }

            return output;
        }

        public async Task<UpdateProductOutputDto> UpdateProductAsync(UpdateProductInputDto aParams)
        {
            var output = new UpdateProductOutputDto();
            try
            {
                var item = new Domain.Models.Product
                {
                    Id = aParams.Id,
                    Name = aParams.Name,
                    Price = aParams.Price,
                    DeliveryPrice = aParams.DeliveryPrice,
                    Description = aParams.Description,
                    ProductOptions = Mapper.Map<List<Domain.Models.ProductOption>>(aParams.ProductOptions)
                };

                await UnitOfWork.ProductRepository.UpdateProductAsync(item);

                await UnitOfWork.SaveChanges();

                var updatedRecord = await UnitOfWork.ProductRepository.GetProductAsync(aParams.Id);
                output = Mapper.Map<UpdateProductOutputDto>(updatedRecord);
            }
            catch (Exception e)
            {
                output.ResultErrors.Messages.Add(e.Message);
            }

            return output;
        }

        public async Task<RemoveProductOutputDto> RemoveProductAsync(RemoveProductInputDto aParams)
        {
            var output = new RemoveProductOutputDto();
            try
            {
                await UnitOfWork.ProductRepository.RemoveProductAsync(aParams.Id);

                await UnitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                output.ResultErrors.Messages.Add(e.Message);
            }

            return output;
        }

        public async Task<GetAllProductsOutputDto> GetAllProductsAsync(GetAllProductsInputDto aParams)
        {
            var output = new GetAllProductsOutputDto();
            try
            {
                List<Domain.Models.Product> result;
                if (!string.IsNullOrWhiteSpace(aParams.ProductName))
                {
                    result = await UnitOfWork.ProductRepository.GetProductAsync(aParams.ProductName);
                }
                else
                {
                     result = await UnitOfWork.ProductRepository.GetAllProductAsync();
                }

                
                output.Items = Mapper.Map<List<ProductItemBase>>(result.ToList());
            }
            catch (Exception e)
            {
                output.ResultErrors.Messages.Add(e.Message);
            }

            return output;
        }

        public async Task<GetProductOutputDto> GetProductAsync(GetProductInputDto aParams)
        {
            var output = new GetProductOutputDto();
            try
            {
                var result = await UnitOfWork.ProductRepository.GetProductAsync(aParams.Id);
                output = Mapper.Map<GetProductOutputDto>(result);
            }
            catch (Exception e)
            {
                output.ResultErrors.Messages.Add(e.Message);
            }

            return output;
        }
    }
}