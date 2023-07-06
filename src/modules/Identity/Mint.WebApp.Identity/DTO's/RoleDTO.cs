using MongoDB.Bson;

namespace Mint.WebApp.Identity.DTO_s;

public record RoleDTO(
    ObjectId? Id = null,
    string? Name = null,
    string? TranslateEn = null,
    string? UniqueKey = null,
    DateTime? CreationDate = null,
    DateTime? UpdateDate = null);

public record RoleSampleDTO(
    ObjectId? Value = null,
    string? Label = null);
