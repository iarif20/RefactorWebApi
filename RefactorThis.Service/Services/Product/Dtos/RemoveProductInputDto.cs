using System;
using System.ComponentModel.DataAnnotations;
using RefactorThis.Service.Framework;

namespace RefactorThis.Service.Services.Product.Dtos
{
    public class RemoveProductInputDto : ApplicationServiceInputBase
    {
        [Required]
        public Guid Id { get; set; }
    }
}