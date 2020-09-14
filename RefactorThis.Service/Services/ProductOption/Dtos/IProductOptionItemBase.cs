using System;
using System.ComponentModel.DataAnnotations;

namespace RefactorThis.Service.Services.ProductOption.Dtos
{
    public interface IProductOptionItemBase
    {
        Guid Id { get; set; }
        Guid ProductId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}