using Mint.Domain.Common;
using Mint.Domain.Models.Base;
using Mint.Domain.Models.Stores;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mint.Domain.Models.Identity;

public class User : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните поле Фамилия")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string FirstName { get; set; } = default!;

    [Required(ErrorMessage = "Заполните поле Имя")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")] 
    public string SecondName { get; set; } = default!;

    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Заполните поле Пароль")]
    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    [MinLength(6, ErrorMessage = "Минимальное кол. 6 символов")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;

    [MaxLength(777, ErrorMessage = "Превышено макс. длина строки (777).")]
    public string? Description { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? DateBirth { get; set; }

    [Required(ErrorMessage = "Заполните поле Пол")]
    public Genders Gender { get; set; } = default!;

    public byte[] Salt { get; set; } = default!;

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

    public List<UserRole> UserRoles { get; set; } = default!;

    public List<Contact> Contacts { get; set; } = default!;

    [JsonIgnore]
    public List<RefreshToken> RefreshTokens { get; set; } = default!;

    public List<UserAddress> UserAddresses { get; set; } = default!;

    public List<StoreReview> StoreReviews { get; set; } = default!;

    public override string ToString()
    {
        return $"#{Id} - FirstName:{FirstName} SecondName:{SecondName}";
    }
}
