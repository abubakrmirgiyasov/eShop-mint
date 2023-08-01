using Mint.Domain.Models.Base;
using Mint.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Stores;

public class StoreReview : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(600, ErrorMessage = "Превышено макс. длина строки (600).")]
    public string Text { get; set; } = null!;

    public double StoreRating { get; set; }

    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!;

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;
}
