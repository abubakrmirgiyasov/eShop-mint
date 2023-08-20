using Mint.Domain.DTO_s.Identity;
using Mint.Domain.DTO_s.Stores;

namespace Mint.Domain.DTO_s.Store;

public class StoreReviewFullBindingModel
{

}

public record StoreReviewFullViewModel(
    Guid? Id = null,
    string? Text = null,
    StoreFullViewModel? Store = null,
    UserFullViewModel? User = null);
