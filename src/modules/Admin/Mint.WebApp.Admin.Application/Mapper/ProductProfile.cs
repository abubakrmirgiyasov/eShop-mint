using AutoMapper;
using Mint.Domain.Models.Admin.Products;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;

namespace Mint.WebApp.Admin.Application.Mapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductFullViewModel>();
    }
}
