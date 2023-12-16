using Mint.Domain.Models.Identity;

namespace Mint.Domain.Common.Data;

/// <summary>
/// Default data for <see cref="UserAddress"/>
/// </summary>
public class UserAddressData
{
    public static List<UserAddress> UserAddresses =>
    [
        new()
        {
            Id = Guid.NewGuid(),
            FullName = UserData.Users[0].ToString(),
            FullAddress = "Таджикистан, г. Худжанд, ул. Тиллокон, дом 12 кв. 49",
            City = "Худжанд",
            Street = "ул. Тиллокон",
            ZipCode = 735700,
            Description = "full address for custom user",
            CountryId = CountryData.Countries[1].Id,
            UserId = UserData.Users[0].Id,
        },
        new()
        {
            Id = Guid.NewGuid(),
            FullName = UserData.Users[0].ToString(),
            FullAddress = "Россия, г. Новосибирск, ул. Заллесского, дом 12 кв. 49",
            City = "Новосибирск",
            Street = "ул. Заллесского",
            ZipCode = 635600,
            Description = "full address for custom user",
            CountryId = CountryData.Countries[1].Id,
            UserId = UserData.Users[1].Id,
        }
    ];
}
