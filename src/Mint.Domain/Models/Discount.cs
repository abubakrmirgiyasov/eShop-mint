using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Discount
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    [MinLength(3, ErrorMessage = "Минимальное кол. символов 6")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле")]
    public int Percent { get; set; }

    public bool IsExpired { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ActiveDateUntil { get; set; }

    public List<Product>? Products { get; set; }
}
