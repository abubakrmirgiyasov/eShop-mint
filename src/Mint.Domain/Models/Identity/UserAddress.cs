using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Identity;

public class UserAddress : Entity<Guid>
{
    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long Phone { get; set; }

    [Required(ErrorMessage = "Заполните поле Адрес")]
    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public string FullAddress { get; set; } = null!;

    [Required(ErrorMessage = "Заполните поле Страна")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string Country { get; set; } = null!;

    [Required(ErrorMessage = "Заполните поле Город")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string City { get; set; } = null!;

    [MaxLength(200, ErrorMessage = "Превышено макс. длина строки (200).")]
    public string? Street { get; set; }

    public int ZipCode { get; set; }

    [StringLength(777, ErrorMessage = "Превышено макс. длина строки (777).")]
    public string? Description { get; set; }

    public Guid? UserId { get; set; }

    public User? User { get; set; } = null!;
}
