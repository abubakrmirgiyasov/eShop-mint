using Microsoft.AspNetCore.Http;
using Mint.Domain.DTO_s.Store;

namespace Mint.Domain.DTO_s.Stores;

public class StoreFullBindingModel
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; } = null!;

    public string? WorkHours { get; set; }
   
    public string? Email { get; set; } = null!;

    public long? Phone { get; set; }

    public double? Rating { get; set; }

    public bool? IsPhysical { get; set; }

    public string? Description { get; set; }

    public IFormFile? Photo { get; set; }

    public Guid? UserId { get; set; }

    public StoreAddressFullBindingModel? StoreAddress { get; set; }

    public StoreCategoryFullBindingModel? StoreCategory { get; set; }
    
    public StoreTagFullBindingModel? StoreTag { get; set; }

    public StoreReviewFullBindingModel? StoreReview { get; set; }
}

public record StoreFullViewModel(
    Guid? Id = null,
    string? Name = null,
    string? Url = null,
    string? Email = null,
    string? WorkHours = null,
    long? Phone = null,
    double? Rating = null,
    bool? IsPhysical = false,
    string? Description = null,
    string? Photo = null,
    List<StoreAddressFullViewModel>? StoreAddresses = null,
    List<StoreCategoryFullViewModel>? StoreCategories = null,
    List<StoreTagSampleViewModel>? StoreTags = null,
    List<StoreReviewFullViewModel>? StoreReviews = null);
