using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface ICommonRepository
{
    Task<List<MenuParentViewModel>> GetMenuAsync();
}
