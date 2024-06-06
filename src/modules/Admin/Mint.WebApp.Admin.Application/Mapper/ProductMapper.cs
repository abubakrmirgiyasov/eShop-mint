using AutoMapper;
using Mint.Domain.Models.Admin.Products;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.Domain.Extensions;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products.ProductReviews;

namespace Mint.WebApp.Admin.Application.Mapper;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductViewModel>();

        CreateMap<Product, ProductInfoViewModel>()
            .IncludeBase<Product, ProductViewModel>()
            .ForMember(x => x.Price, opt => opt.Ignore())
            .ForMember(x => x.OldPrice, opt => opt.Ignore())
            .ForMember(x => x.ProductNumber, opt => opt.Ignore());

        CreateMap<Product, ProductPriceViewModel>()
            .ForMember(x => x.SpecialDateFrom, opt => opt.MapFrom(x => x.SpecialPriceStartDateTimeUtc.FromDateTimeOffset()))
            .ForMember(x => x.SpecialDateTo, opt => opt.MapFrom(x => x.SpecialPriceEndDateTimeUtc.FromDateTimeOffset()));

        CreateMap<ProductReview, ProductReviewViewModel>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(x => x.CreatedDate.FromDateTimeOffset()));
    }
}
