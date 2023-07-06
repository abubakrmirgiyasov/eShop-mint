using Microsoft.Extensions.Options;
using Mint.Domain.Common;
using Mint.Infrastructure.MongoDb.Services;
using Mint.WebApp.Identity.DTO_s;
using Mint.WebApp.Identity.FormingModels;
using Mint.WebApp.Identity.Models;
using MongoDB.Bson;

namespace Mint.WebApp.Identity.Repositories;

public class RoleRepository : Repository<Role>
{
    private readonly ILogger<RoleRepository> _logger;

    public RoleRepository(
        IOptions<MongoDbSettings> settings,
        ILogger<RoleRepository> logger) 
        : base(settings)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get All Roles Async
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Task<IEnumerable<RoleDTO>> GetRolesAsync(CancellationToken cancellationToken)
    {
        try
        {
            var roles = FilterBy(x => x.Name != ".");
            return Task.Run(() => RoleDTOConverter.FormingMultiViewModel(roles), cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Message: {Message}, Inner: {ex}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <summary>
    /// Gets single role by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<RoleDTO> GetRoleByIdAsync(string id)
    {
        try
        {
            var role = await FindByIdAsync(id);
            return RoleDTOConverter.FormingSingleViewModel(role);
        }
        catch (ArgumentNullException ex)
        {
            _logger.LogCritical("Message: {Message}, Inner: {ex}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Message: {Message}, Inner: {ex}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <summary>
    /// Creates new role
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task CreateRoleAsync(RoleDTO model)
    {
        try
        {
            var role = await FindOneAsync(x => x.UniqueKey == model.UniqueKey)
                ?? throw new Exception("Role already exists");

            await InsertOneAsync(RoleDTOConverter.FormingSingleBindingModel(model));
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Message: {Message}, Inner: {ex}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <summary>
    /// Updates role
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task UpdateRoleAsync(RoleDTO model)
    {
        try
        {
            var role = await FindOneAsync(x => x.UniqueKey == model.UniqueKey)
                ?? throw new ArgumentNullException(nameof(model), "Role doesn't exists");
            

        }
        catch (ArgumentNullException ex) 
        {
            throw new ArgumentNullException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <summary>
    /// Deletes role by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task DeleteRoleAsync(string id)
    {
        try
        {
            var role = await FindOneAsync(x => x.Id.ToString() == id)
                ?? throw new ArgumentNullException(nameof(Role), "Role doesn't exists");


        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
