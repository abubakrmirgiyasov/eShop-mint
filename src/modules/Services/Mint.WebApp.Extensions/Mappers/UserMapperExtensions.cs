﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Mint.Domain.DTO_s.Identity;
using Mint.Domain.Models.Identity;

namespace Mint.WebApp.Extensions.Mappers;

public static class UserMapperExtensions
{
    public static IServiceCollection AddUserAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserMapper));

        return services;
    }
}

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserJwtAuthorize>()
            .ForMember(x => x.Roles, opt => opt.MapFrom(x => x.UserRoles.Select(y => y.Role.UniqueKey.ToLower())));
    }
}
