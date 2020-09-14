using System.Threading.Tasks;
using RefactorThis.Service.Services.Product.Dtos;

namespace RefactorThis.Service.Services.Product
{
    public interface IProductService
    {
        Task<AddProductOutputDto> AddProductAsync(AddProductInputDto aParams);
        Task<UpdateProductOutputDto> UpdateProductAsync(UpdateProductInputDto aParams);
        Task<RemoveProductOutputDto> RemoveProductAsync(RemoveProductInputDto aParams);
        Task<GetAllProductsOutputDto> GetAllProductsAsync(GetAllProductsInputDto aParams);
        Task<GetProductOutputDto> GetProductAsync(GetProductInputDto aParams);
    }
}