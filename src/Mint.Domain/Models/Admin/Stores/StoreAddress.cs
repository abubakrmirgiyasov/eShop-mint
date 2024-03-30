using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Admin.Stores;

public class StoreAddress : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public required string Country { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public required string City { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public required string Street { get; set; }

    public required int ZipCode { get; set; }

    [MaxLength(400, ErrorMessage = "Превышено макс. длина строки (400).")]
    public string? Description { get; set; }

    public Guid StoreId { get; set; }

    public Store Store { get; set; } = default!;
}
