using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.WebApp.Admin.Models.Products;

public class Characteristic : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    [MinLength(4, ErrorMessage = "Мин. длина строки (4).")]
    public string Key { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    [MinLength(4, ErrorMessage = "Мин. длина строки (4).")]
    public string Name { get; set; } = null!;

    public List<ProductCharacteristic>? ProductCharacteristics { get; set; }
}
