namespace Mint.WebApp.Identity.DTO_s;

public record RoleDTO(
    Guid? Id = null,
    string? Name = null,
    string? TranslateEn = null,
    string? UniqueKey = null,
    DateTime? CreationDate = null,
    DateTime? UpdateDate = null);

public record RoleSampleDTO(
    string? Value = null,
    string? Label = null);
