namespace Mint.Domain.Common;

public partial class Constants
{
    public const string CONNECTION_STRING = "AppSettings:ConnectionStrings:Default";

    public const string ADMIN = "Админ";
    public const string BUYER = "Покупатель";
    public const string SELLER = "Продавец";

    public const string IMAGE_PATH = "statics/images";

    public const string IMAGE_DEFAULT_NAME = "default-image.png";
    public const string IMAGE_DEFAULT_PATH = "common";

    public const string IDENTITY_KEY = "MintIdentityQueue";
    public const string CONFIRMATION_KEY = "MintIdentityConfirmationQueue";
}

/// <summary>
/// Projects Name
/// </summary>
public enum SchemeNames : int
{
    /// <summary>
    /// None
    /// </summary>
    None = 0,
    /// <summary>
    /// Main project name
    /// </summary>
    Mint = 1,
}

/// <summary>
/// Genders for user
/// </summary>
public enum Genders : int
{
    /// <summary>
    /// Мужской
    /// </summary>
    Male = 0,
    /// <summary>
    /// Женский
    /// </summary>
    Female = 1,
}

public enum AuthType : int
{
    None = 0,
    Admin = 1,
    Client = 2,
}

public enum Roles : int
{
    None = 0,
    Admin = 1,
    Buyer = 2,
    Seller = 3,
}

public enum ContactType : int
{
    Email = 0,
    Phone = 1,
}

public enum SortDirection: int
{
    Ascending = 1,
    Descending = -1,
}
