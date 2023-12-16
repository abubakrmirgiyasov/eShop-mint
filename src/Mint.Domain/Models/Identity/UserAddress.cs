using Mint.Domain.Models.Base;
using Mint.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Identity;

public class UserAddress : Entity<Guid>
{
    public string? FullName { get; set; }

    [Required(ErrorMessage = "Заполните поле Адрес")]
    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public string FullAddress { get; set; } = default!;
        
    [Required(ErrorMessage = "Заполните поле Город")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string City { get; set; } = default!;

    [MaxLength(200, ErrorMessage = "Превышено макс. длина строки (200).")]
    public string? Street { get; set; }

    public int ZipCode { get; set; }

    [StringLength(999, ErrorMessage = "Превышено макс. длина строки (777).")]
    public string? Description { get; set; }

    public Guid CountryId { get; set; }

    public Country Country { get; set; } = default!;

    public Guid UserId { get; set; }

    public User User { get; set; } = default!;
}
