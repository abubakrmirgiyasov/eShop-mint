using Mint.Domain.Models.Identity;

namespace Mint.Domain.Common.Data;

public class RoleData
{
    public static Guid[] Ids => 
    [
        Guid.Parse("68c2f692-2f9a-4d0e-9d89-9c2ff7f0409b"),
        Guid.Parse("22a99751-e418-49c5-ac4e-ce221dd7ae0d"),
        Guid.Parse("7582ed34-eb4a-4628-a7e7-971af7379ec8"),
    ];

    public static List<Role> Roles =>
    [
        new()
        {
            Id = Ids[0],
            Name = Constants.ADMIN,
            TranslateEn = nameof(Constants.ADMIN),
            UniqueKey = nameof(Constants.ADMIN),
        },
        new()
        {
            Id = Ids[1],
            Name = Constants.SELLER,
            TranslateEn = nameof(Constants.SELLER),
            UniqueKey = nameof(Constants.SELLER),
        },
        new()
        {
            Id = Ids[2],
            Name = Constants.BUYER,
            TranslateEn = nameof(Constants.BUYER),
            UniqueKey = nameof(Constants.BUYER),
        },
    ];
}
