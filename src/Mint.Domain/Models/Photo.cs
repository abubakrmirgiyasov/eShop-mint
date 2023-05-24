using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Photo
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(2000, ErrorMessage = "Перевышено макс. длина строки (2000).")]
    public string FileName { get; set; } = null!;

    [MaxLength(30, ErrorMessage = "Перевышено макс. длина строки (30).")]
    public string FileExtension { get; set; } = null!;

    [MaxLength(400, ErrorMessage = "Перевышено макс. длина строки (400).")]
    public string FilePath { get; set; } = null!;

    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string FileType { get; set; } = null!;

    public long FileSize { get; set; }

    public List<User>? Users { get; set; }

    public List<Manufacture>? Manufactures { get; set; }

    public List<Category>? Categories { get; set; }

    public List<ProductPhoto>? ProductPhotos { get; set; }

    public List<ReviewPhoto>? ReviewPhotos { get; set; }
}
