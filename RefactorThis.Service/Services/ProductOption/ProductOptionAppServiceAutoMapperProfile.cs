using AutoMapper;
using RefactorThis.Service.Services.ProductOption.Dtos;

namespace RefactorThis.Service.Services.ProductOption
{
    public class ProductOptionAppServiceAutoMapperProfile : Profile
    {
        public ProductOptionAppServiceAutoMapperProfile()
        {
            CreateMap<Domain.Models.ProductOption, GetProductOptionDetailOutputDto>();
            CreateMap<Domain.Models.ProductOption, AddProductOptionOutputDto>();
            CreateMap<Domain.Models.ProductOption, UpdateProductOptionOutputDto>();

            //CreateMap<Domain.Models.ProductOption, ProductOptionItem>();
            //CreateMap<ProductOptionItem, Domain.Models.ProductOption>();
        }
    }
}