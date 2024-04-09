using AutoMapper;
using Mint.Domain.Models.Identity;
using Mint.WebApp.Identity.Application.Operations.Dtos.Admins;

namespace Mint.WebApp.Identity.Application.Mapper;

public class AdminIdentityMapper : Profile
{
    public AdminIdentityMapper()
    {
        CreateMap<User, AdminInfoViewModel>()
            .ForMember(x => x.ContactInformation, opt => opt.MapFrom(x => x.Contacts.Select(y => y.ContactInformation)))
            .ForMember(x => x.ContactInformationType, opt => opt.MapFrom(x => x.Contacts.Select(y => y.Type)));
    }
}
