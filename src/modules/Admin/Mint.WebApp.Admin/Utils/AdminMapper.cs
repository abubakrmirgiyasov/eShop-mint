using AutoMapper;
using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Admin.Commands.Dtos.Categories;
using Mint.WebApp.Admin.DTO_s.Categories;

namespace Mint.WebApp.Admin.Utils;

public class AdminMapper : Profile
{
    public AdminMapper()
    {
        CreateMap<Category, DefaultLinkDto>();
        CreateMap<Category, CategoryFullViewModel>();
    }
}
