using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using RefactorThis.Service.Framework;

namespace RefactorThis.Service.Services.ProductOption.Dtos
{
    public class AddProductOptionInputDto: ApplicationServiceInputBase, IProductOptionItemBase
    {
        public Guid Id { get; set; } = Guid.Empty;
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name must not exceed 50 characters.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Description must not exceed 500 characters.")]
        public string Description { get; set; }
    }
}