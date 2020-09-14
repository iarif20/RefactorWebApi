using System;

namespace RefactorThis.Service.Services.ProductOption.Dtos
{
    public class ProductOptionItem : IProductOptionItemBase
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}