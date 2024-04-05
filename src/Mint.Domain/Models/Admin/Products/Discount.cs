using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Admin.Products;

public class Discount : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    [MinLength(3, ErrorMessage = "Минимальное кол. символов 3")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле")]
    public int Percent { get; set; }

    public bool IsExpired { get; set; }

    public List<ProductDiscount>? ProductDiscounts { get; set; }
}
