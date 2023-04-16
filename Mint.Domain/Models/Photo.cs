using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Photo
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(800, ErrorMessage = "Перевышено макс. длина строки (800).")]
    public string FileName { get; set; } = null!;

    public string FileExtension { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public List<User>? Users { get; set; }
}
