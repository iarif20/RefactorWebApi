using System;

namespace RefactorThis.Models.ProductOption
{
    public class UpdateProductOptionItemInputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }

    }
}