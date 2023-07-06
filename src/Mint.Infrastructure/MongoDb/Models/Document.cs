using Mint.Infrastructure.MongoDb.Interfaces;
using MongoDB.Bson;

namespace Mint.Infrastructure.MongoDb.Models;

public abstract class Document : IDocument
{
    public ObjectId Id { get; set; }

    public DateTime CreationDate { get; } = DateTime.Now;

    public DateTime? UpdateDate { get; set; }
}
