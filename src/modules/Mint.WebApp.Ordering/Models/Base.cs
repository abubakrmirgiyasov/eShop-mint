using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mint.WebApp.Ordering.Models;

public abstract class Document : IDocument
{
    public ObjectId Id { get; set; }

    public DateTime CreationDate => Id.CreationTime;
}

public interface IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    ObjectId Id { get; set; }

    DateTime CreationDate { get; }
}
