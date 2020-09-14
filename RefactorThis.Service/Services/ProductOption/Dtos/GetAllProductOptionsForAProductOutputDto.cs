using System.Collections.Generic;
using RefactorThis.Service.Framework;

namespace RefactorThis.Service.Services.ProductOption.Dtos
{
    public class GetAllProductOptionsForAProductOutputDto: ApplicationServiceOutputBase
    {
        public List<IProductOptionItemBase> Items { get; set; } = new List<IProductOptionItemBase>();
    }
}