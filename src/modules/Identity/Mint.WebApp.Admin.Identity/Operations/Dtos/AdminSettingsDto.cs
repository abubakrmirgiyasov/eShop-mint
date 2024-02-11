namespace Mint.WebApp.Admin.Identity.Operations.Dtos;

public class AdminSettingsDto
{
    public required string FirstName { get; set; }

    public required string SecondName { get; set; }

    public required string LastName { get; set; }

    public required int Gender { get; set; }

    public IFormFile? Background { get; set; }

    public IFormFile? Photo { get; set; }
}
