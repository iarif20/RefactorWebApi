using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorThis.Service.Services.Product.Dtos
{
    public interface IProductItemBase
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        decimal DeliveryPrice { get; set; }
        List<ProductOptionItem> ProductOptions { get; set; }
    }
}
