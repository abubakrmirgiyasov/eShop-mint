using Mint.Domain.Models.Identity;

namespace Mint.Domain.Common.Data;

public class RoleData
{
    public static Guid Id => Guid.NewGuid();

    public static List<Role> Roles =>
    [
        new()
        {
            Id = Id,
            Name = Constants.ADMIN,
            TranslateEn = nameof(Constants.ADMIN),
            UniqueKey = nameof(Constants.ADMIN),
        },
        new()
        {
            Id = Id,
            Name = Constants.SELLER,
            TranslateEn = nameof(Constants.SELLER),
            UniqueKey = nameof(Constants.SELLER),
        },
        new()
        {
            Id = Id,
            Name = Constants.BUYER,
            TranslateEn = nameof(Constants.BUYER),
            UniqueKey = nameof(Constants.BUYER),
        },
    ];
}
