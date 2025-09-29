using System.ComponentModel;

namespace Teslacode.Common.Extensions;

public static class EnumExtensions
{
    public static T ParseEnum<T>(this string value) => (T)Enum.Parse(typeof(T), value, true);

    public static T ParseEnum<T>(this int intValue) => (T)Enum.ToObject(typeof(T), intValue);

    public static T? ParseFromDescription<T>(this string description)
    {
        var fields = typeof(T).GetFields();
        var field = fields.SelectMany(sm => sm.GetCustomAttributes(typeof(DescriptionAttribute), false), (sm, a) => new { Field = sm, Att = a })
                          .Where(a => ((DescriptionAttribute)a.Att).Description == description)
                          .SingleOrDefault();

        return field == null ? default : (T?)field.Field.GetRawConstantValue();
    }

    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribs = field?.GetCustomAttributes(typeof(DescriptionAttribute), true);
        return attribs?.Length > 0 ? ((DescriptionAttribute)attribs[0]).Description : string.Empty;
    }

    public static string? GetEnumString<T>(this int intValue)
    {
        var enumType = (T)Enum.ToObject(typeof(T), intValue);
        return enumType?.ToString();
    }
}