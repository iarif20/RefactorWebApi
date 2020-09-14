using System;
using System.Collections.Generic;
using System.Threading;

namespace RefactorThis.Domain.Models
{
    public class Product
    {
        public Product()
        {
            
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
        public List<ProductOption> ProductOptions { get; set; } = new List<ProductOption>();
    }
}