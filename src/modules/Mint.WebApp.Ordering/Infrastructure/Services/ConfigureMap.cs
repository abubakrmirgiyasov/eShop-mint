using Mint.WebApp.Ordering.Models;
using MongoDB.Bson.Serialization;

namespace Mint.WebApp.Ordering.Infrastructure.Services;

public static class ConfigureMap
{
    public static void Configure()
    {
        BsonClassMap.RegisterClassMap<Order>(map =>
        {
            //map.AutoMap();
            //map.SetIgnoreExtraElements(true);
            //map.MapIdMember(x => x.OrderId);
            //map.MapMember(x => x.Id);
            //map.MapMember(x => x.RowVersion);
            //map.MapMember(x => x.UpdateDateTime);
            //map.MapMember(x => x.CreatedDate);

            //.SetIsRequired(true);
        });
    }
}
