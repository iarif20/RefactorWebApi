using System;
using RefactorThis.Service.Framework;

namespace RefactorThis.Service.Services.Product.Dtos
{
    public class GetProductInputDto : ApplicationServiceInputBase
    {
        public Guid Id { get; set; }
    }
}