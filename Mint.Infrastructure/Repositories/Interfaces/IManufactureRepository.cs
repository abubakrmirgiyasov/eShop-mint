using Mint.Domain.BindingModels;
using Mint.Domain.ViewModels;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface IManufactureRepository
{
    Task<List<ManufactureViewModel>> GetManufacturesAsync();

    Task<ManufactureViewModel> GetManufactureByIdAsync(Guid id);

    Task AddManufactureAsync(ManufactureBindingModel model);

    Task UpdateManufactureAsync(ManufactureBindingModel model);

    Task DeleteManufactureAsync(Guid id);
}
