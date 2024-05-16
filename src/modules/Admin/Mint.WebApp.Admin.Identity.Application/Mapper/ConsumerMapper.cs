using AutoMapper;
using Mint.Domain.Models.Identity;
using Mint.WebApp.Admin.Identity.Application.Operations.Dtos;

namespace Mint.WebApp.Admin.Identity.Application.Mapper;

public class ConsumerMapper : Profile
{
    public ConsumerMapper()
    {
        CreateMap<User, AdminInfoViewModel>()
            .ForMember(x => x.ContactInformation, opt => opt.MapFrom(x => x.Contacts.Select(y => y.ContactInformation)))
            .ForMember(x => x.ContactInformationType, opt => opt.MapFrom(x => x.Contacts.Select(y => y.Type)));
    }
}
