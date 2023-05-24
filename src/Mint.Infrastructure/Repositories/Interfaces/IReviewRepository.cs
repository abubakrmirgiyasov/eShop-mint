using Mint.Domain.BindingModels;
using Mint.Domain.ViewModels;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface IReviewRepository
{
    Task<List<ReviewViewModel>> GetReviewsAsync();

    Task<List<ReviewViewModel>> GetProductReviewsByIdAsync(Guid id);

    Task<ReviewViewModel> NewReviewAsync(ReviewBindingModel model);

    Task<ReviewViewModel> UpdateReviewAsync(ReviewBindingModel model);

    Task DeleteReviewAsync(Guid id);
}
