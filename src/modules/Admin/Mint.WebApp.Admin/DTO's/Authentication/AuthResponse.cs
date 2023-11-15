namespace Mint.WebApp.Admin.DTO_s.Authentication;

public record AuthResponse(
    Guid? Id = null,
    string? Token = null,
    string[]? Roles = null);
