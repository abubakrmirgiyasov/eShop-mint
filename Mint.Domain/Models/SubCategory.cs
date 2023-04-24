using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class SubCategory
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните поле Название")]
    [MaxLength(100, ErrorMessage = "Перевышено макс. длина строки (100).")]
    public string Name { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public Guid? CategoryId { get; set; }

    public Category? Category { get; set; }
}
