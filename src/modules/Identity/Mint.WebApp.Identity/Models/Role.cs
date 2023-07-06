using Mint.Infrastructure.MongoDb.Attributes;
using Mint.Infrastructure.MongoDb.Models;

namespace Mint.WebApp.Identity.Models;

[BsonCollection("roles")]
public class Role : Document
{
    public string Name { get; set; } = null!;

    public string TranslateEn { get; set; } = null!;

    public string UniqueKey { get; set; } = null!;

    public List<UserRole> UserRoles { get; set; } = null!;
}
