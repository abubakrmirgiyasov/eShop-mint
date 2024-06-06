namespace Mint.WebApp.Admin.Application.Operations.Dtos.Products.ProductReviews;

public class ProductReviewViewModel
{
    public required DateOnly CreatedDate { get; set; }

    public string? Pluses { get; set; }

    public string? Minuses { get; set; }

    public string? Text { get; set; }

    public string? CommentType { get; set; }

    public required double Rating { get; set; }

    public required int CountOfVoted { get; set; }
}
