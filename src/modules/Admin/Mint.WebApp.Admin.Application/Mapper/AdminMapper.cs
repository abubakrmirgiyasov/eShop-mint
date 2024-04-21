using AutoMapper;
using Mint.Domain.Models.Admin.Categories;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.Domain.Models.Admin.Tags;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Application.Operations.Dtos.Tags;

namespace Mint.WebApp.Admin.Application.Mapper;

public class AdminMapper : Profile
{
    public AdminMapper()
    {
        CreateMap<Category, CategoryFullViewModel>();
        CreateMap<Category, CategoryInfoViewModel>();
        CreateMap<Category, CategorySimpleViewModel>()
            .ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id));

        CreateMap<SubCategory, SubCategoryInfoViewModel>();
        CreateMap<SubCategory, SubCategorySimpleViewModel>()
            .ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id));

        CreateMap<Manufacture, ManufactureFullViewModel>();
        CreateMap<ManufactureContact, ManufactureContactDto>();

        CreateMap<TagFullViewModel, TagFullBindingModel>();

        CreateMap<Tag, TagFullViewModel>()
            .ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id));

        CreateMap<Tag, TagSampleViewModel>()
            .ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id));

        CreateMap<CategoryTag, CategoryTagViewModel>();
    }
}
