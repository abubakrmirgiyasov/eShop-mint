using AutoMapper;
using Mint.Domain.Models.Admin.Categories;
using Mint.Domain.Models.Admin;
using Mint.WebApp.Admin.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Operations.Dtos;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.WebApp.Admin.Operations.Dtos.Manufactures;

namespace Mint.WebApp.Admin.Utils;

public class AdminMapper : Profile
{
    public AdminMapper()
    {
        CreateMap<Category, DefaultLinkDTO>();
        CreateMap<Category, CategoryFullViewModel>();

        CreateMap<Category, CategorySampleViewModel>()
            .ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id));

        CreateMap<SubCategory, SubCategoryFullViewModel>();
        CreateMap<SubCategory, SubCategorySampleViewModel>()
            .ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id));

        CreateMap<Manufacture, ManufactureFullViewModel>();
        CreateMap<ManufactureContact, ManufactureContactDto>();

        CreateMap<TagFullViewModel, TagFullBindingModel>();

        CreateMap<Tag, TagFullViewModel>()
            .ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id));
    }
}
