using AutoMapper;
using Mint.Domain.DTO_s.Identity;
using Mint.Domain.Models.Identity;

namespace Mint.Application.Mapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserJwtAuthorize>()
            .ForMember(x => x.Roles, opt => opt.MapFrom(x => x.UserRoles.Select(y => y.Role.UniqueKey.ToLower())));
    }
}
