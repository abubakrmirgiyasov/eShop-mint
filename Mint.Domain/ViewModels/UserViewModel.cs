namespace Mint.Domain.ViewModels;

public class UserFullViewModel
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public long? Phone { get; set; }

    public string? Description { get; set; }

    public string? Gender { get; set; }

    public bool IsConfirmedEmail { get; set; }

    public DateTime DateBirth { get; set; }
}
