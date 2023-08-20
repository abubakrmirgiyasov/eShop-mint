using Mint.Domain.DTO_s.Identity;

namespace Mint.Infrastructure.Repositories.Identity.Interfaces;

/// <summary>
/// Role Repository Interface
/// </summary>
public interface IRoleRepository
{
    /// <summary>
    /// This method gets all roles
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<RoleDTO>> GetRolesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// This gets single role by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<RoleDTO> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Method create new role
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task CreateRoleAsync(RoleDTO model, CancellationToken cancellationToken = default);

    /// <summary>
    /// Method to update role
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task UpdateRoleAsync(RoleDTO model, CancellationToken cancellationToken = default);

    /// <summary>
    /// Method to delete role
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteRoleAsync(Guid id, CancellationToken cancellationToken = default);
}
