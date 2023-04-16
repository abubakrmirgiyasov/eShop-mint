using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните поле Фамилия")]
    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Заполните поле Имя")]
    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string SecondName { get; set; } = null!;

    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string? LastName { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Заполните поле Почта")]
    [DataType(DataType.EmailAddress)]
    [MaxLength(255, ErrorMessage = "Перевышено макс. длина строки (255).")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Заполните поле Телефон")]
    [DataType(DataType.PhoneNumber)]
    public long Phone { get; set; }

    [Required(ErrorMessage = "Заполните поле Пароль")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Минимальное кол. букв 6")]
    [MaxLength(255, ErrorMessage = "Перевышено макс. длина строки (255).")]
    public string Password { get; set; } = null!;

    [MaxLength(777, ErrorMessage = "Перевышено макс. длина строки (777).")]
    public string? Description { get; set; }

    public DateTime DateBirth { get; set; }

    public string Gender { get; set; } = null!;

    public int ZipCode { get; set; }

    public byte[] Salt { get; set; } = null!;

    public string Ip { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public int NumOfAttempts { get; set; } = 0;

    public bool IsConfirmedEmail { get; set; } = false;

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public List<UserRole>? UserRoles { get; set; }

    public List<RefreshToken>? RefreshTokens { get; set; }
}
