using System;
using RefactorThis.Service.Framework;

namespace RefactorThis.Service.Services.ProductOption.Dtos
{
    public class RemoveProductOptionInputDto: ApplicationServiceInputBase
    {
        public Guid Id { get; set; }
    }
}