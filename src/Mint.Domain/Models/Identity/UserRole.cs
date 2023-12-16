namespace Mint.Domain.Models.Identity;

public class UserRole
{
    public Guid UserId { get; set; }

    public User User { get; set; } = default!;

    public Guid RoleId { get; set; }

    public Role Role { get; set; } = default!;
}
