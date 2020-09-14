using System.Collections.Generic;
using RefactorThis.Models.ProductOption;

namespace RefactorThis.Models.Product
{
    public class CreateProductItemInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
        public List<AttachProductOptionItemInputModel> ProductOptions { get; set; } = new List<AttachProductOptionItemInputModel>();
    }
}