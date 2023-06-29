using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Role : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните поле Название")]
    [MaxLength(50, ErrorMessage = "Максимальная длина строки 50")]
    [MinLength(4, ErrorMessage = "Минимальная длина строки 4")]
    public string Name { get; set; } = null!;
    
    public List<UserRole> UserRoles { get; set; } = null!;

    public List<User> Users { get; set; } = null!;
}
