using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

    [JsonIgnore]
    public object? TEntities { get; set; }

    //public List<Manufacture>? Manufactures { get; set; }

    //public List<Category>? Categories { get; set; }

    //public List<ProductPhoto>? ProductPhotos { get; set; }

    //public List<ReviewPhoto>? ReviewPhotos { get; set; }
}
