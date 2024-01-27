using Mint.Domain.Models.Admin.Categories;
using Mint.Domain.Models.Base;
using Mint.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations;
using Mint.Domain.Models.Stores;
using Mint.Domain.Models.Admin.Manufactures;

namespace Mint.Domain.Models;

public class Photo : Entity<Guid>
{
    [StringLength(4000, ErrorMessage = "Превышено макс. длина строки (2000).")]
    public string FileName { get; set; } = null!;

    [MaxLength(30, ErrorMessage = "Превышено макс. длина строки (30).")]
    public string FileExtension { get; set; } = null!;

    [MaxLength(400, ErrorMessage = "Превышено макс. длина строки (400).")]
    public string FilePath { get; set; } = null!;

    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string FileType { get; set; } = null!;

    public long FileSize { get; set; }

    public List<User>? UserBackgroundPhotos { get; set; }

    public List<User>? UserPhotos { get; set; }

    public List<Manufacture>? Manufactures { get; set; }

    public List<Category>? Categories { get; set; }

    public List<ProductPhoto>? ProductPhotos { get; set; }

    public List<Store>? Stores { get; set; }
}
