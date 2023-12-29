using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.StorageCloud.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Mint.WebApp.StorageCloud.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MiniosController(IStorageCloudService storageService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetSingleImage(
        [FromQuery, Required] string bucket,
        [FromQuery, Required] string name,
        CancellationToken cancellationToken = default)
    {
        return Ok(await storageService.GetFileLinkAsync(name, bucket, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult> Create(
        [FromForm] Models.StorageCloud storageCloud,
        CancellationToken cancellationToken)
    {
        await storageService.UploadFileAsync(storageCloud.File, storageCloud.Bucket, cancellationToken);
        return NoContent();
    }
}
