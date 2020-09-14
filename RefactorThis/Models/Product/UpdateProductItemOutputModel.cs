using System;
using System.Collections.Generic;
using RefactorThis.Service.Services.Product.Dtos;

namespace RefactorThis.Models.Product
{
    public class UpdateProductItemOutputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }

        public List<ProductOptionItem> ProductOptions { get; set; }
    }
}