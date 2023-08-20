using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Stores;

public class StoreAddress : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string Country { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public string Street { get; set; } = null!;

    public int ZipCode { get; set; }

    [MaxLength(400, ErrorMessage = "Превышено макс. длина строки (400).")]
    public string? Description { get; set; }

    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!;
}
