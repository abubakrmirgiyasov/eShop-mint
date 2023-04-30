using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class CommonCharacteristic
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(50, ErrorMessage = "Перевышено макс. длина строки (50).")]
    public string? Color { get; set; }

    [MaxLength(50, ErrorMessage = "Перевышено макс. длина строки (50).")]
    public string? Material { get; set; }

    public double Rate { get; set; }

    public int Garanty { get; set; }

    public DateTime ReleaseDate { get; set; }

    public bool Availability { get; set; }

    public double Weight { get; set; }

    public double Length { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public List<Product>? Products { get; set; }
}
