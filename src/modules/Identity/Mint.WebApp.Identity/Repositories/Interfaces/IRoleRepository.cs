﻿using Mint.WebApp.Identity.DTO_s;

namespace Mint.WebApp.Identity.Repositories.Interfaces;

/// <summary>
/// Role Repository Interface
/// </summary>
public interface IRoleRepository
{
    /// <summary>
    /// This method gets all roles
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<RoleDTO>> GetRolesAsync();

    /// <summary>
    /// This gets single role by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<RoleDTO> GetRoleByIdAsync(Guid id);

    /// <summary>
    /// Method create new role
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task CreateRoleAsync(RoleDTO model);

    /// <summary>
    /// Method to update role
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task UpdateRoleAsync(RoleDTO model);

    /// <summary>
    /// Method to delete role
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteRoleAsync(Guid id);
}
