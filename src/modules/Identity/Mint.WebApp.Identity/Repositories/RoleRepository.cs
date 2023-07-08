using Microsoft.EntityFrameworkCore;
using Mint.WebApp.Identity.DTO_s;
using Mint.WebApp.Identity.FormingModels;
using Mint.WebApp.Identity.Models;
using Mint.WebApp.Identity.Repositories.Interfaces;
using Mint.WebApp.Identity.Services;

namespace Mint.WebApp.Identity.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly ILogger<RoleRepository> _logger;
    private readonly ApplicationDbContext _context;

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
    public async Task<IEnumerable<RoleDTO>> GetRolesAsync()
    {
        try
        {
            var roles = await _context.Roles.ToListAsync();
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
    public async Task<RoleDTO> GetRoleByIdAsync(Guid id)
    {
        try
        {
            var roles = await _context.Roles.ToListAsync();
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
    public async Task CreateRoleAsync(RoleDTO model)
    {
        try
        {
            var roles = await _context.Roles.ToListAsync();
            var role = roles.FirstOrDefault(x => x.UniqueKey == model.UniqueKey);

            if (role != null)
                throw new Exception("Role already exists");
            
            await _context.Roles.AddAsync(RoleDTOConverter.FormingSingleBindingModel(model));
            await _context.SaveChangesAsync();
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
            var roles = await _context.Roles.ToListAsync();
            var role = roles.FirstOrDefault(x => x.UniqueKey == model.UniqueKey)
                ?? throw new ArgumentNullException(nameof(Role), "Role doesn't exists");

            _context.Roles.Update(RoleDTOConverter.FormingSingleBindingModel(model));
            await _context.SaveChangesAsync();
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
    public async Task DeleteRoleAsync(Guid id)
    {
        try
        {
            var roles = await _context.Roles.ToListAsync();
            var role = roles.FirstOrDefault(x => x.Id == id)
                ?? throw new ArgumentNullException(nameof(Role), "Role doesn't exists");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
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
