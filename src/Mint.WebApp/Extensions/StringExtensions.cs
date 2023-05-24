namespace Mint.WebApp.Extensions;

public static class StringExtensions
{
    public static bool IsNull(this string? value)
    {
        return string.IsNullOrEmpty(value);
    }

    public static bool IsNullOrWhiteSpace(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    public static string GetImage(this string value)
    {
        byte[] bytes = File.ReadAllBytes(value ?? "ifnull.png");
        return "data:image/*;base64," + Convert.ToBase64String(bytes);
    }
}
