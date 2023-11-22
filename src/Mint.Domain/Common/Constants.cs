namespace Mint.Domain.Common;

public class Constants
{
    public const string CONNECTION_STRING = "Default";

    public const string ADMIN = "Админ";
    public const string BUYER = "Покупатель";
    public const string SELLER = "Продавец";

    public const string IMAGE_PATH = "statics/images";

    public const string IDENTITY_KEY = "MintIdentityQueue";
    public const string CONFIRMATION_KEY = "MintIdentityConfirmationQueue";

    public const string REDIS_SAMPLE_CATEGORIES = "REDIS_SAMPLE_CATEGORIES";
    public const string REDIS_SAMPLE_TAGS = "REDIS_SAMPLE_TAGS";

    public enum AuthType : int
    {
        None = 0,
        Admin = 1,
        Client = 2,
    }
}

public enum Roles : int
{
    None = 0,
    Admin = 1,
    Buyer = 2,
    Seller = 3,
}
