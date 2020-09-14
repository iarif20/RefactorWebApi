using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RefactorThis.Service.Services.ProductOption.Dtos;

namespace RefactorThis.Service.Services.ProductOption
{
    public interface IProductOptionService
    {
        Task<AddProductOptionOutputDto> AddProductOption(AddProductOptionInputDto aParams);
        Task<UpdateProductOptionOutputDto> UpdateProductOption(UpdateProductOptionInputDto aParams);
        Task<RemoveProductOptionOutputDto> RemoveProductOption(RemoveProductOptionInputDto aParams);
        Task<GetProductOptionDetailOutputDto> GetProductOptionDetail(GetProductOptionDetailInputDto aParams);
        Task<GetAllProductOptionsForAProductOutputDto> GetAllProductOptionsForAProduct(GetAllProductOptionsForAProductInputDto aParams);
    }
}
