using AutoMapper;
using Mint.Domain.Models.Admin;

namespace Mint.WebApp.Admin.DTO_s;

public class TagFullBindingModel
{
    public Guid? Value { get; set; }

    public string? Label { get; set; }

    public string? Translate { get; set; }
}

public class TagFullViewModel
{
    public Guid? Value { get; set; }

    public string? Label { get; set; }
    
    public string? Translate { get; set; }
}

public class AutoMappingTag : Profile
{
    public AutoMappingTag()
    {
        CreateMap<TagFullViewModel, TagFullBindingModel>();

        CreateMap<Tag, TagFullViewModel>()
            .ForMember(x => x.Label, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Value, y => y.MapFrom(z => z.Id));

        CreateMap<Tag, TagFullBindingModel>()
            .ForMember(x => x.Label, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Value, y => y.MapFrom(z => z.Id));
    }
}