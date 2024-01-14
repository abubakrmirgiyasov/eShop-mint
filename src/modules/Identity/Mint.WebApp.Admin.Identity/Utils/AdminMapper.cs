using AutoMapper;
using Mint.Domain.Models.Identity;
using Mint.WebApp.Admin.Identity.Commands.Dtos;

namespace Mint.WebApp.Admin.Identity.Utils;

public class AdminMapper : Profile
{
    public AdminMapper()
    {
        CreateMap<User, AdminInfoDto>()
            .ForMember(x => x.ContactInformation, opt => opt.MapFrom(x => x.Contacts.Select(y => y.ContactInformation)))
            .ForMember(x => x.ContactInformationType, opt => opt.MapFrom(x => x.Contacts.Select(y => y.Type)));
    }
}
