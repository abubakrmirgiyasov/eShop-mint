using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.WebApp.Admin.Models.Products;

public class CommonCharacteristic : Entity<Guid>
{
    [MaxLength(50, ErrorMessage = "Превышено макс. длина строки (50).")]
    public string? Color { get; set; }

    [MaxLength(50, ErrorMessage = "Превышено макс. длина строки (50).")]
    public string? Material { get; set; }

    public double Rate { get; set; }

    public int Guaranty { get; set; }

    public DateTime ReleaseDate { get; set; }

    public bool Availability { get; set; }

    public double Weight { get; set; }

    public double Length { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public Guid? ProductId { get; set; }

    public Product? Product { get; set; }
}
