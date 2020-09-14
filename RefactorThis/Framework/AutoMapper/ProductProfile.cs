using AutoMapper;
using RefactorThis.Models.Product;
using RefactorThis.Models.ProductOption;
using RefactorThis.Service.Services.Product.Dtos;
using RefactorThis.Service.Services.ProductOption.Dtos;
using ProductOptionItem = RefactorThis.Service.Services.Product.Dtos.ProductOptionItem;

namespace RefactorThis.Framework.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductItemBase, ProductItemModel>();
            CreateMap<ProductItemBase, GetProductItemOutputModel>();
            CreateMap<ProductOptionItem, AttachProductOptionItemOutputModel>();
            CreateMap<GetProductOutputDto, GetProductItemOutputModel>();
            CreateMap<CreateProductItemInputModel, AddProductInputDto>();
            CreateMap<AttachProductOptionItemInputModel, ProductOptionItem>();
            CreateMap<AddProductOutputDto, CreateProductItemOutputModel>();
            CreateMap<ProductOptionItem, AttachProductOptionItemOutputModel>();
            CreateMap<UpdateProductItemInputModel, UpdateProductInputDto>();
            CreateMap<RemoveProductOutputDto, RemoveProductItemOutputModel>();
            CreateMap<UpdateProductOutputDto, UpdateProductItemOutputModel>()
                .ForSourceMember(x => x.ProductOptions, opt => opt.DoNotValidate());
            CreateMap<GetProductOptionDetailOutputDto, GetProductOptionItemOutputByIdAndProductIdModel>();

            CreateMap<AddProductOptionOutputDto, CreateProductOptionItemOutputModel>();

            CreateMap<UpdateProductOptionOutputDto, UpdateProductOptionItemOutputModel>();

            CreateMap<RemoveProductOptionOutputDto, RemoveProductOptionItemOutputModel>();
        }
    }
}