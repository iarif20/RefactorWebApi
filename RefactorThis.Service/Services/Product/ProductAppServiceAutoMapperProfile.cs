using System.Collections.Generic;
using AutoMapper;
using RefactorThis.Domain.Models;
using RefactorThis.Service.Services.Product.Dtos;

namespace RefactorThis.Service.Services.Product
{
    public class ProductAppServiceAutoMapperProfile : Profile
    {
        public ProductAppServiceAutoMapperProfile()
        {
            CreateMap<Domain.Models.Product, ProductItemBase>();
            CreateMap<Domain.Models.ProductOption, ProductOptionItem>();
            CreateMap<Domain.Models.Product, GetProductOutputDto>();
            CreateMap<ProductOptionItem,Domain.Models.ProductOption>();

            CreateMap<Domain.Models.Product, AddProductOutputDto>();
            CreateMap<Domain.Models.ProductOption, ProductOptionItem>();


            CreateMap<Domain.Models.Product, UpdateProductOutputDto>();
            CreateMap<Domain.Models.ProductOption, ProductOptionItem>();

            


        }
    }
}