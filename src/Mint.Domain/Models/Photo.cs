using Mint.Domain.Models.Admin.Categories;
using Mint.Domain.Models.Base;
using Mint.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.Domain.Models.Admin.Products;
using Mint.Domain.Models.Admin.Stores;

namespace Mint.Domain.Models;

public class Photo : Entity<Guid>
{
    [StringLength(2000, ErrorMessage = "Превышено макс. длина строки (2000).")]
    public required string FileName { get; set; }

    [MaxLength(30, ErrorMessage = "Превышено макс. длина строки (30).")]
    public required string FileExtension { get; set; }

    [MaxLength(400, ErrorMessage = "Превышено макс. длина строки (400).")]
    public required string FilePath { get; set; }

    /// <summary>
    /// Bucket
    /// </summary>
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public required string Bucket { get; set; }

    public required long FileSize { get; set; }

    public List<User>? UserBackgroundPhotos { get; set; }

    public List<User>? UserPhotos { get; set; }

    public List<Manufacture>? Manufactures { get; set; }

    public List<Category>? Categories { get; set; }

    public List<ProductPhoto>? ProductPhotos { get; set; }

    public List<Store>? Stores { get; set; }

    public List<ProductReviewPhoto>? ProductReviewPhotos { get; set; }
}
