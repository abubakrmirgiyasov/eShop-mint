using Mint.Infrastructure.MongoDb.Attributes;
using MongoDB.Bson;

namespace Mint.WebApp.Identity.Models;

[BsonCollection("user_roles")]
public class UserRole
{
    public ObjectId UserId { get; set; }

    public ObjectId RoleId { get; set; }

    public User User { get; set; } = null!;

    public Role Role { get; set; } = null!;
}
