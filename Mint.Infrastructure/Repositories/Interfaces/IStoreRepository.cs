using Mint.Domain.BindingModels;
using Mint.Domain.ViewModels;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface IStoreRepository
{
    Task<StoreFullViewModel> GetStoresAsync();

    Task<StoreFullViewModel> GetMyStoreAsync(Guid id);
    
    Task<StoreFullViewModel> CreateStoreAsync(StoreFullBindingModel model);
}
