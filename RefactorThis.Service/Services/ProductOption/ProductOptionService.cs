using System;
using System.Threading.Tasks;
using RefactorThis.Service.Framework;
using RefactorThis.Service.Services.ProductOption.Dtos;
using IUnitOfWork = RefactorThis.Data.Repositories.IUnitOfWork;

namespace RefactorThis.Service.Services.ProductOption
{
    public class ProductOptionService : ApplicationService, IProductOptionService
    {
        private readonly IUnitOfWork UnitOfWork;

        public ProductOptionService(IUnitOfWork aUnitOfWork)
        {
            UnitOfWork = aUnitOfWork;
        }
        public async Task<AddProductOptionOutputDto> AddProductOption(AddProductOptionInputDto aParams)
        {
            var output = new AddProductOptionOutputDto();
            try
            {
                var item = new Domain.Models.ProductOption
                {
                    Name = aParams.Name,
                    ProductId = aParams.ProductId,
                    Description = aParams.Description
                };
                var result = await UnitOfWork.ProductOptionRepository.AddProductOptionsAsync(item);
                output = Mapper.Map<AddProductOptionOutputDto>(result);


            }
            catch (Exception e)
            {
                output.ResultErrors.Messages.Add(e.Message);
            }

            return output;
        }

        public async Task<UpdateProductOptionOutputDto> UpdateProductOption(UpdateProductOptionInputDto aParams)
        {
            var output = new UpdateProductOptionOutputDto();
            try
            {
                var item = new Domain.Models.ProductOption
                {
                    Id = aParams.Id,
                    Name = aParams.Name,
                    ProductId = aParams.ProductId,
                    Description = aParams.Description
                };
                var result = await UnitOfWork.ProductOptionRepository.UpdateProductOptionsAsync(item);
                 output = Mapper.Map<UpdateProductOptionOutputDto>(result);

            }
            catch (Exception e)
            {
                output.ResultErrors.Messages.Add(e.Message);
            }

            return output;
        }

        public async Task<RemoveProductOptionOutputDto> RemoveProductOption(RemoveProductOptionInputDto aParams)
        {
            RemoveProductOptionOutputDto output = new RemoveProductOptionOutputDto();
            try
            {
                await UnitOfWork.ProductOptionRepository.RemoveProductOptionsAsync(aParams.Id);
                await UnitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                output.ResultErrors.Messages.Add(e.Message);
            }

            return output;
        }

        public async Task<GetProductOptionDetailOutputDto> GetProductOptionDetail(
            GetProductOptionDetailInputDto aParams)
        {
            var output = new GetProductOptionDetailOutputDto();
            try
            {
                var result = await UnitOfWork.ProductOptionRepository.GetProductOptionByDetailsAsync(aParams.Id);
                output = Mapper.Map<GetProductOptionDetailOutputDto>(result);
                return output;
            }
            catch (Exception e)
            {
                output.ResultErrors.Messages.Add(e.Message);
            }

            return output;
        }

        public async Task<GetAllProductOptionsForAProductOutputDto> GetAllProductOptionsForAProduct(
            GetAllProductOptionsForAProductInputDto aParams)
        {
            var output = new GetAllProductOptionsForAProductOutputDto();
            try
            {
                await UnitOfWork.ProductOptionRepository.GetAllProductOptionsByProductAsync(aParams.ProductId);
                await UnitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                output.ResultErrors.Messages.Add(e.Message);
            }

            return output;
        }
    }
}