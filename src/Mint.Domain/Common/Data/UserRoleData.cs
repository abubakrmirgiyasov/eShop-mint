using Mint.Domain.Models.Identity;

namespace Mint.Domain.Common.Data;

public class UserRoleData
{
    public static List<UserRole> UserRoles =>
    [
        new() { UserId = UserData.Users[0].Id, RoleId = RoleData.Roles[0].Id, },
        new() { UserId = UserData.Users[0].Id, RoleId = RoleData.Roles[1].Id, },
        new() { UserId = UserData.Users[0].Id, RoleId = RoleData.Roles[2].Id, },
        new() { UserId = UserData.Users[1].Id, RoleId = RoleData.Roles[0].Id, },
        new() { UserId = UserData.Users[1].Id, RoleId = RoleData.Roles[1].Id, },
        new() { UserId = UserData.Users[1].Id, RoleId = RoleData.Roles[2].Id, },
    ];
}
