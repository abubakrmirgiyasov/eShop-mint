namespace Mint.WebApp.Identity.Application.Operations.Dtos.Admins;

public class AdminInfoViewModel
{
    public required string FirstName { get; set; }

    public required string SecondName { get; set; }

    public string? LastName { get; set; }

    public required string[] ContactInformation { get; set; }

    public required string[] ContactInformationType { get; set; }

    public required string Gender { get; set; }

    public required string Avatar { get; set; }
}
