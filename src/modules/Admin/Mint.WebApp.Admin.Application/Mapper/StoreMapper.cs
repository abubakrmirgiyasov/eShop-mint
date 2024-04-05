using AutoMapper;
using Mint.Domain.Models.Admin.Stores;
using Mint.WebApp.Admin.Application.Operations.Dtos.Stores;

namespace Mint.WebApp.Admin.Application.Mapper;

public class StoreMapper : Profile
{
    public StoreMapper()
    {
        CreateMap<Store, SimpleStoreViewModel>();
    }
}
