using System;
using System.Collections.Generic;
using RefactorThis.Models.ProductOption;

namespace RefactorThis.Models.Product
{
    public class CreateProductItemOutputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
        public List<AttachProductOptionItemOutputModel> ProductOptions { get; set; } = new List<AttachProductOptionItemOutputModel>();
    }
}