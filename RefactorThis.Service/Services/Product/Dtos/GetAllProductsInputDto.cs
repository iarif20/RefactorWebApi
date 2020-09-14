using RefactorThis.Service.Framework;

namespace RefactorThis.Service.Services.Product.Dtos
{
    public class GetAllProductsInputDto : ApplicationServiceInputBase
    {
        public string ProductName { get; set; } = string.Empty;
    }
}