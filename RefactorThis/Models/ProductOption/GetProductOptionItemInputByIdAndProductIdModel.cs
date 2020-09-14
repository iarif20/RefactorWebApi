using System;

namespace RefactorThis.Models.ProductOption
{
    public class GetProductOptionItemInputByIdAndProductIdModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
    }
}