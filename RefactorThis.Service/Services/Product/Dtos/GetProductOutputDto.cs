using System;
using System.Collections.Generic;
using RefactorThis.Service.Framework;
using RefactorThis.Service.Services.ProductOption.Dtos;

namespace RefactorThis.Service.Services.Product.Dtos
{
    public class GetProductOutputDto : ApplicationServiceOutputBase, IProductItemBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
        public List<ProductOptionItem> ProductOptions { get; set; }
    }
}