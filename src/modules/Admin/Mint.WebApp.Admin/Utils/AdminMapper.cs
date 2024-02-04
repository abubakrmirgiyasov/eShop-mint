﻿using AutoMapper;
using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Admin.Commands.Dtos.Categories;
using Mint.WebApp.Admin.DTO_s;
using Mint.WebApp.Admin.DTO_s.Categories;
using Mint.Domain.Models.Admin;

namespace Mint.WebApp.Admin.Utils;

public class AdminMapper : Profile
{
    public AdminMapper()
    {
        CreateMap<Category, DefaultLinkDto>();
        CreateMap<Category, CategoryFullViewModel>();

        CreateMap<TagFullViewModel, TagFullBindingModel>();

        CreateMap<Tag, TagFullViewModel>()
            .ForMember(x => x.Label, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Value, y => y.MapFrom(z => z.Id));

        CreateMap<Tag, TagFullBindingModel>()
            .ForMember(x => x.Label, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Value, y => y.MapFrom(z => z.Id));
    }
}
