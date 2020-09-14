using System;

namespace RefactorThis.Models.Product
{
    public class UpdateProductItemInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}