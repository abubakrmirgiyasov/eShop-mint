﻿using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mint.Domain.Models;

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
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Заполните поле Телефон")]
    [DataType(DataType.PhoneNumber)]
    public long Phone { get; set; }

    [Required(ErrorMessage = "Заполните поле Пароль")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Минимальное кол. букв 6")]
    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public string Password { get; set; } = null!;

    [MaxLength(777, ErrorMessage = "Превышено макс. длина строки (777).")]
    public string? Description { get; set; }

    public DateTime DateBirth { get; set; }

    public string Gender { get; set; } = null!;

    public byte[] Salt { get; set; } = null!;

    public string Ip { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public int NumOfAttempts { get; set; } = 0;

    public bool IsConfirmedEmail { get; set; } = false;

    public string? UserAgent { get; set; }

    public string? AcceptLanguage { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public List<Order>? Orders { get; set; }

    public List<UserRole>? UserRoles { get; set; }

    [JsonIgnore]
    public List<RefreshToken>? RefreshTokens { get; set; }

    public List<Address> Addresses { get; set; } = null!;

    public List<Store>? Stores { get; set; }

    public List<Review>? Reviews { get; set; }

    public List<LikedProduct> LikedProducts { get; set; } = null!;
}
