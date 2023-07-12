using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Attributes;
using Mint.Domain.Common;
using Mint.WebApp.Identity.DTO_s;
using Mint.WebApp.Identity.Repositories;

namespace Mint.WebApp.Identity.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(Roles = Constants.ADMIN)]
public class RoleController : ControllerBase
{
    private readonly RoleRepository _role;

    public RoleController(RoleRepository role)
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
