using System;
using System.Collections.Generic;
using RefactorThis.Service.Framework;

namespace RefactorThis.Service.Services.ProductOption.Dtos
{
    public class GetAllProductOptionsForAProductInputDto: ApplicationServiceInputBase
    {
        public Guid ProductId { get; set; }
    }
}