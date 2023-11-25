namespace Mint.Domain.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Returns string with first letter upper
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static string FirstCharToUpper(this string str)
    {
        return str switch
        {
            null => throw new ArgumentNullException(nameof(str)),
            "" => throw new ArgumentException($"{nameof(str)} cannot be empty", nameof(str)),
            _ => string.Concat(str[0].ToString().ToUpper(), str.AsSpan(1)),
        };
    }

    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }
}
