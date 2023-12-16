using Mint.Domain.Models.Identity;

namespace Mint.Domain.Common.Data;

public class UserData
{
    private static readonly byte[] _salt = new Hasher().GetSalt();

    public static Guid[] Ids => 
    [
        Guid.Parse("e256100b-0328-4a16-924a-76bdf987e6a0"),
        Guid.Parse("2448250c-0fc7-464b-9872-ce6a17de0572"),
    ];

    public static List<User> Users =>
    [
        new()
        {
            Id = Ids[0],
            FirstName = "Миргиясов",
            SecondName = "Абубакр",
            LastName = "Мукимжонович",
            Ip = "127.0.0.1",
            Password = new Hasher().GetHash("AbuakrMirgiyasov@))!M", _salt),
            NumOfAttempts = 0,
            Salt = _salt,
            Description = "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428",
            Gender = Genders.Male,
            DateBirth = new DateTime(2001, 12, 5),
            IsActive = true,
            IsConfirmedEmail = true,
        },
        new()
        {
            Id = Ids[1],
            FirstName = "Test",
            SecondName = "User",
            Ip = "127.0.0.2",
            Password = new Hasher().GetHash("test_1", _salt),
            NumOfAttempts = 0,
            Salt = _salt,
            Gender = Genders.Female,
            DateBirth = new DateTime(2003, 10, 1),
            Description = "Test User Почта: test@gmail.com Телефон: 83452763423",
            IsActive = true,
            IsConfirmedEmail = true,
        },
    ];
}
