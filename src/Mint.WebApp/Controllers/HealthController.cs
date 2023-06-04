using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Mint.Domain.Common;
using Mint.WebApp.Attributes;
using System.Net;

namespace Mint.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = Constants.ADMIN)]
public class HealthController : ControllerBase
{
    private readonly ILogger<HealthController> _logger;
    private readonly HealthCheckService _health;

    public HealthController(ILogger<HealthController> logger, HealthCheckService health)
    {
        _health = health;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var report = await _health.CheckHealthAsync();
        _logger.LogInformation("Get health Information: ", report);
        return report.Status == HealthStatus.Healthy 
            ? Ok(report) 
            : StatusCode((int)HttpStatusCode.ServiceUnavailable, report);
    }
}
