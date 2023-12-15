namespace Mint.Domain.Common;

public partial class Constants
{
    public const string CONNECTION_STRING = "AppSettings:ConnectionStrings:Default";

    public const string ADMIN = "Админ";
    public const string BUYER = "Покупатель";
    public const string SELLER = "Продавец";

    public const string IMAGE_PATH = "statics/images";

    public const string IDENTITY_KEY = "MintIdentityQueue";
    public const string CONFIRMATION_KEY = "MintIdentityConfirmationQueue";
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
