using Mint.Domain.Models.Base;
using Mint.Domain.Models.Identity;
using Mint.Domain.Models.Stores;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Admin.Stores;

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

    public bool IsPhysical { get; set; }

    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public string? Description { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; } = default!;

    public List<StoreAddress> StoreAddresses { get; set; } = default!;

    public List<StoreCategory>? StoreCategories { get; set; }

    public List<StoreTag>? StoreTags { get; set; }

    public List<StoreReview> StoreReviews { get; set; } = default!;

    public List<Storage>? Storages { get; set; }

    public List<StoreContact> StoreContacts { get; set; } = default!;
}
