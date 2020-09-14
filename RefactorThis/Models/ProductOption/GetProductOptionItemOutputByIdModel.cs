using System;

namespace RefactorThis.Models.ProductOption
{
    public class GetProductOptionItemOutputByIdModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}