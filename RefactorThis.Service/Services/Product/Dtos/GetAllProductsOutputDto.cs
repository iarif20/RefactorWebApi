using System.Collections.Generic;
using RefactorThis.Service.Framework;

namespace RefactorThis.Service.Services.Product.Dtos
{
    public class GetAllProductsOutputDto : ApplicationServiceOutputBase
    {
        public List<ProductItemBase> Items { get; set; } = new List<ProductItemBase>();
    }
}