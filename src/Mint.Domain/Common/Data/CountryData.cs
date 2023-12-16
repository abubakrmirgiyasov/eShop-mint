using Mint.Domain.Models.Common;

namespace Mint.Domain.Common.Data;

public class CountryData
{
    public static Guid[] Ids => 
    [
        Guid.Parse("3616c928-a4d1-4dfb-a622-1d750bbb5739"),    
        Guid.Parse("e8fc7423-4c93-4465-bfb4-8db45abb1296"),    
        Guid.Parse("6f7652b5-92de-4a44-9342-a68a4b92ff52"),
    ];

    public static List<Country> Countries =>
    [
        new() 
        {
            Id = Ids[0],
            Name = "Россия",
            CountryCode = "RU-ru"
        },
        new()
        {
            Id = Ids[1],
            Name = "Тоҷикистон",
            CountryCode = "TJ-tj"
        },
        new()
        {
            Id = Ids[2],
            Name = "Қазақстан",
            CountryCode = "KZ-kz"
        },
    ];
}
