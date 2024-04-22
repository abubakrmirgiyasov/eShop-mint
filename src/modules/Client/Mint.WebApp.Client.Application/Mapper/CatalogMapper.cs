using AutoMapper;
using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Client.Application.Operations.Dtos.Categories;

namespace Mint.WebApp.Client.Application.Mapper;

public class CatalogMapper : Profile
{
    public CatalogMapper()
    {
        CreateMap<Category, Catalog>();
    }
}
