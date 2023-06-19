using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mint.Infrastructure.MongoDb.Interfaces;

public interface IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    ObjectId Id { get; set; }

    DateTime CreationDate { get; }

    DateTime? UpdateDate { get; set; }
}
