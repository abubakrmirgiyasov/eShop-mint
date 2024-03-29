﻿using Microsoft.AspNetCore.Mvc;
using Mint.Domain.DTO_s.Identity;
using Mint.Infrastructure.Repositories.Identity.Interfaces;

namespace Mint.WebApp.Identity.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RoleController : ControllerBase
{
    private readonly IRoleRepository _role;

    public RoleController(IRoleRepository role)
    {
        _role = role;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles(CancellationToken cancellationToken)
    {
        try
        {
            var roles = await _role.GetRolesAsync(cancellationToken);
            return Ok(roles);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleById(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var role = await _role.GetRoleByIdAsync(id, cancellationToken);
            return Ok(role);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleDTO model, CancellationToken cancellationToken)
    {
        try
        {
            await _role.CreateRoleAsync(model, cancellationToken);
            return Ok(new { message = "Role was created successfully" });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRole([FromBody] RoleDTO model, CancellationToken cancellationToken)
    {
        try
        {
            await _role.UpdateRoleAsync(model, cancellationToken);
            return Ok(new { message = "Updated successfully" });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _role.DeleteRoleAsync(id, cancellationToken);
            return Ok(new { message = "Deleted successfully" });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}
