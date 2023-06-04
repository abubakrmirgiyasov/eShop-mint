using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Common;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;

namespace Mint.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = Constants.ADMIN)]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employee; 

    public EmployeeController(IEmployeeRepository employee)
    {
        _employee = employee;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        try
        {
            var employees = await _employee.GetEmployeesAsync();
            return Ok(employees);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
