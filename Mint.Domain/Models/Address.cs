using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Address
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [DataType(DataType.DateTime)]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Заполните поле Адрес")]
    [MaxLength(255, ErrorMessage = "Перевышено макс. длина строки (255).")]
    public string FullAddress { get; set; } = null!;

    [Required(ErrorMessage = "Заполните поле Страна")]
    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string Country { get; set; } = null!;

    [Required(ErrorMessage = "Заполните поле Город")]
    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string City { get; set; } = null!;

    public int ZipCode { get; set; }

    [StringLength(777, ErrorMessage = "Перевышено макс. длина строки (777).")]
    public string? Description { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;
}