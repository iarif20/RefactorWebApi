using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RefactorThis.Service.Framework;

namespace RefactorThis.Service.Services.Product.Dtos
{
    public class UpdateProductInputDto : ApplicationServiceInputBase, IProductItemBase 
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name must not exceed 50 characters.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Description must not exceed 500 characters.")]
        public string Description { get; set; }

        [Required] public decimal Price { get; set; }

        [Required] public decimal DeliveryPrice { get; set; }
        public List<ProductOptionItem> ProductOptions { get; set; } = new List<ProductOptionItem>();
    }
}