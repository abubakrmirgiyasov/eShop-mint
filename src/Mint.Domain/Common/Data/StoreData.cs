using Mint.Domain.Models.Admin.Stores;

namespace Mint.Domain.Common.Data;

public class StoreData
{
    public static Guid Id = Guid.Parse("d307c97f-2ebf-4b77-a35b-f728ebaaad0d");

    public static Store[] Stores =>
    [
        new()
        {
            Id = Id,
            Name = "Mint",
            Url = "mint",
            IsPhysical = false,
            UserId = UserData.Ids[1]
        }
    ];
}
