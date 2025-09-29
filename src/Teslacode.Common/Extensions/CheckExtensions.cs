namespace Teslacode.Common.Extensions;

public static class CheckExtensions
{
    public static bool IsNotNull<T>(this T value) where T : class
    {
        return value != null;
    }
}
