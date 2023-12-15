using Mint.Domain.Models.Common;

namespace Mint.Domain.Common.Data;

public class CountryData
{
    public static Guid Id => Guid.NewGuid();

    public static List<Country> Countries =>
    [
        new() 
        {
            Id = Id,
            Name = "Россия",
            CountryCode = "RU-ru"
        },
        new()
        {
            Id = Id,
            Name = "Тоҷикистон",
            CountryCode = "TJ-tj"
        },
        new()
        {
            Id = Id,
            Name = "Қазақстан",
            CountryCode = "KZ-kz"
        },
    ];
}
