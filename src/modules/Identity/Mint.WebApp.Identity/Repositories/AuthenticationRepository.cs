using Microsoft.Extensions.Options;
using Mint.Domain.Common;
using Mint.Infrastructure.MongoDb.Services;
using Mint.WebApp.Identity.Models;

namespace Mint.WebApp.Identity.Repositories;

public class AuthenticationRepository : Repository<User>
{
    public AuthenticationRepository(IOptions<MongoDbSettings> settings)
        : base(settings) { }

    
}
