using Mint.Domain.Models.Base;
using Mint.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Admin.Stores;

public class StoreReview : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(600, ErrorMessage = "Превышено макс. длина строки (600).")]
    public required string Text { get; set; }

    public double StoreRating { get; set; }

    public int CountOfVoted { get; set; }

    public Guid StoreId { get; set; }

    public Store Store { get; set; } = default!;

    public Guid UserId { get; set; }

    public User User { get; set; } = default!;
}
