using Mint.Domain.Common;
using Mint.Infrastructure.MessageBrokers;
using Mint.WebApp.Admin.DTO_s.Categories;
using Mint.WebApp.Admin.Utils;

namespace Mint.WebApp.Admin;

public static class ConfigureAdminServices
{
    public static IServiceCollection AdminServicesCollection(this IServiceCollection services, AppSettings appSettings)
    {
        // Mapper
        services.AddAutoMapper(typeof(AdminMapper));

        // Message brokers
        services.AddMessageBusSender<CategoryPhoto>(appSettings.MessageBroker);

        return services;
    }
}
