using System;
using System.Collections.Generic;

namespace RefactorThis.Service.Services.Product.Dtos
{
    public class ProductItemBase : IProductItemBase
    {
        public ProductItemBase()
        {
            ProductOptions = new List<ProductOptionItem>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
        public List<ProductOptionItem> ProductOptions { get; set; }
    }
}