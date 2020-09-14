using System;
using RefactorThis.Service.Framework;

namespace RefactorThis.Service.Services.ProductOption.Dtos
{
    public class AddProductOptionOutputDto: ApplicationServiceOutputBase, IProductOptionItemBase
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}