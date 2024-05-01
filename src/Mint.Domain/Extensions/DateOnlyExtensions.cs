namespace Mint.Domain.Extensions;

public static class DateOnlyExtensions
{
    /// <summary>
    /// Converts a DateTimeOffset to a DateOnly.
    /// </summary>
    /// <param name="date">The DateTimeOffset to convert.</param>
    /// <returns>The DateOnly value.</returns>
    public static DateOnly FromDateTimeOffset(this DateTimeOffset date)
    {
        return DateOnly.FromDateTime(date.UtcDateTime.Date);
    }

    /// <summary>
    /// Converts a nullable DateTimeOffset to a nullable DateOnly.
    /// </summary>
    /// <param name="date">The nullable DateTimeOffset to convert.</param>
    /// <returns>The nullable DateOnly value.</returns>
    public static DateOnly? FromDateTimeOffset(this DateTimeOffset? date)
    {
        if (!date.HasValue)
            return null;

        return DateOnly.FromDateTime(date.Value.UtcDateTime.Date);
    }
}
