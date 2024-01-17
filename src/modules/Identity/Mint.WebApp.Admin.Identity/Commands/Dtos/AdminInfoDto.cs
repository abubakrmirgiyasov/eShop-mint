namespace Mint.WebApp.Admin.Identity.Commands.Dtos;

public class AdminInfoDto
{
    public string FirstName { get; set; } = default!;

    public string SecondName { get; set; } = default!;

    public string? LastName { get; set; }

    public string[] ContactInformation { get; set; } = default!;

    public string[] ContactInformationType { get; set; } = default!;

    public string Gender { get; set; } = default!;

    public string Avatar { get; set; } = default!;
}
