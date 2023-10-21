namespace Mint.Domain.DTO_s.Identity;

public class UserFullBindingModel
{
    public Guid? Id { get; set; }

    public string? FirstName { get; set; }
    
    public string? SecondName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? Email { get; set; }
    
    public string? Password { get; set; }

    public string? NewPassword { get; set; }

    public long? Phone { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime? DateBirth { get; set; }
    
    public string? Gender { get; set; }
    
    public string? Ip { get; set; }
    
    public bool? IsActive { get; set; }
    
    public int? NumOfAttempts { get; set; }
    
    public bool? IsConfirmedEmail { get; set; }
    
    public bool? IsConfirmedPhone { get; set; }
    
    public string? UserAgent { get; set; }
    
    public string? AcceptLanguage { get; set; }

    public byte[]? Salt { get; set; }
}

public class UserSignInBindingModel
{
    public string? Ip { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}

public record UserFullViewModel(
    Guid? Id = null,
    string? FirstName = null,
    string? SecondName = null,
    string? LastName = null,
    string? Email = null,
    string? Password = null,
    long? Phone = null,
    string? Description = null,
    DateTime? DateBirth = null,
    string? Gender = null,
    string? Ip = null,
    bool? IsActive = null,
    int? NumOfAttempts = null,
    bool? IsConfirmedEmail = null,
    bool? IsConfirmedPhone = null,
    string? UserAgent = null,
    string? AcceptLanguage = null,
    string? Photo = null,
    List<RoleSampleDTO>? Roles = null);
