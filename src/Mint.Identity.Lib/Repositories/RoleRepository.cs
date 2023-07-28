using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mint.Domain.Models.Identity;
using Mint.Identity.Lib.DTO_s;
using Mint.Identity.Lib.FormingModels;
using Mint.Identity.Lib.Repositories.Interfaces;
using Mint.Identity.Lib.Services;

namespace Mint.Identity.Lib.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly ILogger<RoleRepository> _logger;
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Consturctor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    public RoleRepository(ILogger<RoleRepository> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

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
