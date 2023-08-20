using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Stores;

public class Store : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    [DataType(DataType.Url)]
    public string Url { get; set; } = null!;

    public string? WorkHours { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [DataType(DataType.PhoneNumber)]
    public long Phone { get; set; }

    public double Rating { get; set; }

    public bool IsPhysical { get; set; }

    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public string? Description { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public List<StoreAddress> StoreAddresses { get; set; } = null!;

    public List<StoreCategory>? StoreCategories { get; set; }

    public List<StoreTag>? StoreTags { get; set; }

    public List<StoreReview> StoreReviews { get; set; } = null!;
}
