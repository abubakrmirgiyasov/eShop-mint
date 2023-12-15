using Mint.Domain.Models.Identity;

namespace Mint.Domain.Common.Data;

public class UserData
{
    private static readonly byte[] _salt = new Hasher().GetSalt();

    public static Guid Id => Guid.NewGuid();

    public static List<User> Users =>
    [
        new()
        {
            Id = Id,
            FirstName = "Миргиясов",
            SecondName = "Абубакр",
            LastName = "Мукимжонович",
            Ip = "127.0.0.1",
            Password = new Hasher().GetHash("AbuakrMirgiyasov@))!M", _salt),
            NumOfAttempts = 0,
            Salt = _salt,
            Description = "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428",
            Gender = "M",
            DateBirth = new DateTime(2001, 12, 5),
            IsActive = true,
            IsConfirmedEmail = true,
            Contacts =
            [
                new()
                {
                    Id = Id,
                    Type = ContactType.Phone,
                    ContactInformation = "+79502768428"
                },
                new()
                {
                    Id = Id,
                    Type = ContactType.Email,
                    ContactInformation = "abubakrmirgiyasov@gmail.com"
                }
            ]
        },
        new()
        {
            Id = Id,
            FirstName = "Test",
            SecondName = "User",
            Ip = "127.0.0.2",
            Password = new Hasher().GetHash("test_1", _salt),
            NumOfAttempts = 0,
            Salt = _salt,
            Gender = "F",
            DateBirth = new DateTime(2003, 10, 1),
            Description = "Test User Почта: test@gmail.com Телефон: 83452763423",
            IsActive = true,
            IsConfirmedEmail = true,
            Contacts =
            [
                new()
                {
                    Id = Id,
                    Type = ContactType.Email,
                    ContactInformation = "admin@mint.com"
                },
                new()
                {
                    Id = Id,
                    Type = ContactType.Phone,
                    ContactInformation = "+73452763423"
                }
            ]
        },
    ];
}
