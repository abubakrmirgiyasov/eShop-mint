namespace Mint.Domain.Extensions;

public static class TimeOnlyExtensions
{
    public static readonly TimeOnly EndOfDay = new(23, 59, 59, 999);
}
