using Mint.Infrastructure.MongoDb.Attributes;
using Mint.Infrastructure.MongoDb.Models;

namespace Mint.WebApp.Ordering.Models;

[BsonCollection("orders")]
public class Order : Document
{
    public int OrderNumber { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
