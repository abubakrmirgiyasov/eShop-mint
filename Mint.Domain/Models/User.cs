namespace Mint.Domain.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; } = null!;
    
    public string SecondName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
