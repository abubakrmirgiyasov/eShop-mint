using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.Identity.DTO_s;
using Mint.WebApp.Identity.Repositories;
using MongoDB.Bson;

namespace Mint.WebApp.Identity.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
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

    [HttpGet]
    public async Task<IActionResult> GetRoleById(string id)
    {
        try
        {
            var role = await _role.GetRoleByIdAsync(id);
            return Ok(role);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleDTO model)
    {
        try
        {
            await _role.CreateRoleAsync(model);
            return Ok(new { message = "Role was created successfully" });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRole([FromBody] RoleDTO model)
    {
        try
        {
            await _role.UpdateRoleAsync(model);
            return Ok(new { message = "Updated successfully" });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRole(string id)
    {
        try
        {
            await _role.DeleteRoleAsync(id);
            return Ok(new { message = "Deleted successfully" });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}
