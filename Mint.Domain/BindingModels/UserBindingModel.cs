namespace Mint.Domain.BindingModels;

public class UserSigninBindingModel
{
    public string? Email { get; set; }

    public string? Password { get; set; }
}

public class UserFullBindingModel
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public long? Phone { get; set; }

    public string? Ip { get; set; }

    public string? Password { get; set; }

    public string? Description { get; set; }

    public string? Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public PhotoFullBindingModel? Photo { get; set; }
}