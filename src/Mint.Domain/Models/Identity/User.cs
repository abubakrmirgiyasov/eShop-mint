using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mint.Domain.Models.Identity;

public class User : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните поле Фамилия")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Заполните поле Имя")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")] 
    public string SecondName { get; set; } = null!;

    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Заполните поле Почта")]
    [DataType(DataType.EmailAddress)]
    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Заполните поле Телефон")]
    [DataType(DataType.PhoneNumber)]
    public long? Phone { get; set; }

    [Required(ErrorMessage = "Заполните поле Пароль")]
    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    [MinLength(6, ErrorMessage = "Минимальное кол. букв 6")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [MaxLength(777, ErrorMessage = "Превышено макс. длина строки (777).")]
    public string? Description { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? DateBirth { get; set; }

    [Required(ErrorMessage = "Заполните поле Пол")]
    public string Gender { get; set; } = null!;

    public byte[] Salt { get; set; } = null!;

    public string? Ip { get; set; }

    public bool IsActive { get; set; } = false;

    public bool IsSeller { get; set; } = false;

    public int NumOfAttempts { get; set; } = 0;

    public int ConfirmationCode { get; set; } = 0;

    public bool IsConfirmedEmail { get; set; } = false;

    public bool IsConfirmedPhone { get; set; } = false;

    public bool IsDeleted { get; set; } = false;

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public List<UserRole> UserRoles { get; set; } = null!;

    [JsonIgnore]
    public List<RefreshToken> RefreshTokens { get; set; } = null!;

    public List<UserAddress>? UserAddresses { get; set; }

    public override string ToString()
    {
        return $"{Id} {FirstName} {SecondName} {Email} {Phone} {Ip}";
    }
}
