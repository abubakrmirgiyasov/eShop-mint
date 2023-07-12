namespace Mint.Domain.Models.Identity;

public class UserRole
{
    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public User User { get; set; } = null!;

    public Role Role { get; set; } = null!;
}
