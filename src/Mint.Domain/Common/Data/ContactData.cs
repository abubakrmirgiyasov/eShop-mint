using Mint.Domain.Models.Identity;

namespace Mint.Domain.Common.Data;
public class ContactData
{
    public static Guid[] Ids =>
    [
        Guid.Parse("5f33ad47-a973-418c-a6b7-08660a4bd652"),
        Guid.Parse("70298181-e41d-41a9-86c5-ac349a74af6d"),
        Guid.Parse("83733797-4c73-457a-874b-cba254c6d71e"),
        Guid.Parse("66e835d3-7aaf-42be-9e7d-970173e4bae7"),
    ];

    public static Contact[] Contacts =>
    [
        new()
        {
            Id = Ids[0],
            Type = ContactType.Phone,
            ContactInformation = "+79502768428",
            UserId = UserData.Ids[0],
        },
        new()
        {
            Id = Ids[1],
            Type = ContactType.Email,
            ContactInformation = "abubakrmirgiyasov@gmail.com",
            UserId = UserData.Ids[0],
        },
        new()
        {
            Id = Ids[2],
            Type = ContactType.Email,
            ContactInformation = "admin@mint.com",
            UserId = UserData.Ids[1],
        },
        new()
        {
            Id = Ids[3],
            Type = ContactType.Phone,
            ContactInformation = "+73452763423",
            UserId = UserData.Ids[1],
        }
    ];
}
