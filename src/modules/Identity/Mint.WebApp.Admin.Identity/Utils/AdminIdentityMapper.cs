using AutoMapper;
using Mint.Domain.Models.Identity;
using Mint.WebApp.Admin.Identity.Operations.Dtos;

namespace Mint.WebApp.Admin.Identity.Utils;

public class AdminIdentityMapper : Profile
{
    public AdminIdentityMapper()
    {
        CreateMap<User, AdminInfoDto>()
            .ForMember(x => x.ContactInformation, opt => opt.MapFrom(x => x.Contacts.Select(y => y.ContactInformation)))
            .ForMember(x => x.ContactInformationType, opt => opt.MapFrom(x => x.Contacts.Select(y => y.Type)));
    }
}
