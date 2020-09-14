using System;

namespace RefactorThis.Service.Services.Product.Dtos
{
    public class ProductOptionItem
    {
        public ProductOptionItem()
        {

        }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}