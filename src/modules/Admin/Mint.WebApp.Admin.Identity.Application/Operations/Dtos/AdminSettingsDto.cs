using Microsoft.AspNetCore.Http;
using Mint.Domain.Common;

namespace Mint.WebApp.Admin.Identity.Application.Operations.Dtos;

public class AdminSettingsBindingModel
{
    public required string FirstName { get; set; }

    public required string SecondName { get; set; }

    public string? LastName { get; set; }

    public required Genders Gender { get; set; }

    public string? Folder { get; set; }

    public IFormFile? Background { get; set; }

    public IFormFile? Photo { get; set; }
}
