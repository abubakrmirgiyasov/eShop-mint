using Mint.Domain.Models.Base;
using Mint.WebApp.Ordering.Attributes;
using MongoDB.Bson;

namespace Mint.WebApp.Ordering.Models;

[BsonCollection("orders")]
public class Order : Document
{
    public int OrderNumber { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
