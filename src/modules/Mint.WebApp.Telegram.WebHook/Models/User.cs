using Mint.Infrastructure.MongoDb.Attributes;
using Mint.Infrastructure.MongoDb.Models;

namespace Mint.WebApp.Telegram.WebHook.Models;

[BsonCollection("users")]
public class User : Document
{
    public long ChatId { get; set; }

    public string? Message { get; set; }
}
