using System;

namespace RefactorThis.Domain.Models
{
    public class ProductOption
    {
        public ProductOption()
        {
            
        }
        public Guid Id { get; set; } = new Guid();
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}