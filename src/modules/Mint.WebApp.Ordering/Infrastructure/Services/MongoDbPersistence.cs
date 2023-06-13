using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace Mint.WebApp.Ordering.Infrastructure.Services;

public static class MongoDbPersistence
{
    public static void Configure()
    {
        ConfigureMap.Configure();
        //BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));
        BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

        var pack = new ConventionPack()
        {
            new IgnoreExtraElementsConvention(true),
            new IgnoreIfDefaultConvention(true),
        };

        ConventionRegistry.Register("My solution Convertions", pack, x => true);
    }
}
