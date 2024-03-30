namespace Mint.Domain.Models.Admin.Products;

public class ProductReviewPhoto
{
    public Guid? ProductReviewId { get; set; }

    public ProductReview? ProductReview { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }
}
