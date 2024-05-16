using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mint.Application.Repositories;
using Mint.Domain.DTO_s.Identity;
using Mint.Domain.FormingModels.Identity;
using Mint.Domain.Models.Identity;

namespace Mint.Infrastructure.Repositories.Identity;

/// <inheritdoc cref="IRoleRepository"/>
internal sealed class RoleRepository(
    ApplicationDbContext context,
    ILogger<RoleRepository> logger
) : GenericRepository<User>(context), IRoleRepository
{
    private readonly ApplicationDbContext _context = context;
    private readonly ILogger<RoleRepository> _logger = logger;

    /// <summary>
    /// Get All Roles Async
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<IEnumerable<RoleDTO>> GetRolesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var roles = await _context.Roles.ToListAsync(cancellationToken);
            return RoleDTOConverter.FormingMultiViewModel(roles);
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
    public async Task<RoleDTO> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var roles = await _context.Roles.ToListAsync(cancellationToken);
            var role = roles.FirstOrDefault(x => x.Id == id)
                ?? throw new ArgumentNullException(nameof(Role), "Role wasn't found");

            return RoleDTOConverter.FormingSingleViewModel(role);
        }
        catch (ArgumentNullException ex)
        {
            _logger.LogCritical("Message: {Message}, Inner: {ex}", ex.Message, ex);
            throw new ArgumentNullException(ex.Message, ex);
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
    public async Task CreateRoleAsync(RoleDTO model, CancellationToken cancellationToken = default)
    {
        try
        {
            var roles = await _context.Roles.ToListAsync(cancellationToken);
            var role = roles.FirstOrDefault(x => x.UniqueKey == model.UniqueKey);

            if (role != null)
                throw new Exception("Role already exists");
            
            await _context.Roles.AddAsync(RoleDTOConverter.FormingSingleBindingModel(model), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
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
    public async Task UpdateRoleAsync(RoleDTO model, CancellationToken cancellationToken = default)
    {
        try
        {
            var roles = await _context.Roles.ToListAsync(cancellationToken);
            var role = roles.FirstOrDefault(x => x.UniqueKey == model.UniqueKey)
                ?? throw new ArgumentNullException(nameof(Role), "Role doesn't exists");

            _context.Roles.Update(RoleDTOConverter.FormingSingleBindingModel(model));
            await _context.SaveChangesAsync(cancellationToken);
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
    public async Task DeleteRoleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var roles = await _context.Roles.ToListAsync(cancellationToken);
            var role = roles.FirstOrDefault(x => x.Id == id)
                ?? throw new ArgumentNullException(nameof(Role), "Role doesn't exists");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync(cancellationToken);
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
