namespace Teslacode.Common.Extensions;

public static class CastingExtensions
{
    public static long Tolong(this string value) => long.Parse(value);

    public static Guid ToGuid(this string value) => Guid.Parse(value);

    public static int ToInt(this string value) => int.Parse(value);

    public static Int16 ToSmallInt(this string value) => Int16.Parse(value);
}
