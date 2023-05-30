using Mint.Domain.BindingModels;
using Mint.Domain.ViewModels;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface ICommonRepository
{
    Task<List<MenuParentViewModel>> GetMenuAsync();

    Task<List<ProductFullViewModel>> SearchAsync(string query);

    Task<List<LikeViewModel>> GetMyLikesAsync(Guid id);

    Task<List<LikeViewModel>> NewLikeAsync(LikeBindingModel model);

    Task RemoveLike(LikeBindingModel model);
}
