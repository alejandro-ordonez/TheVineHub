using System.Globalization;
using MudBlazor;

namespace JMMinistry.Web.Extensions
{
    public static class UIConverters
    {
        public static readonly IConverter<DateOnly, string> DateOnlyConverter = Conversions.From<DateOnly, string>(
            value => value.ToString("yyyy-MM-dd"),
            text => DateOnly.Parse(text ?? "", CultureInfo.InvariantCulture));

        public static readonly IConverter<DateOnly?, string> NullableDateOnlyConverter = Conversions.From<DateOnly?, string>(
            value => value?.ToString("yyyy-MM-dd") ?? "",
            text => string.IsNullOrEmpty(text) ? null : DateOnly.Parse(text, CultureInfo.InvariantCulture));
    }
}
