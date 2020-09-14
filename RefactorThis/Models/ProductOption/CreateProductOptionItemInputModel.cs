using System;

namespace RefactorThis.Models.ProductOption
{
    public class CreateProductOptionItemInputModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}