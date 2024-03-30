using Mint.Domain.Models.Base;
using Mint.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Admin.Products;

public class ProductReview : Entity<Guid> 
{
    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255)")]
    public string? Pluses { get; set; }

    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255)")]
    public string? Minuses { get; set; }

    [MaxLength(800, ErrorMessage = "Превышено макс. длина строки (800)")]
    public string? Text { get; set; }

    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255)")]
    public string? CommentType { get; set; }

    public double Rating { get; set; }

    public int CountOfVoted { get; set; }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = default!;

    public Guid? UserId { get; set; }

    public User? User { get; set; }

    public List<ProductReviewPhoto>? ProductReviewPhotos { get; set; }
}
