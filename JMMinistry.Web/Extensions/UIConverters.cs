using System.Globalization;

namespace JMMinistry.Web.Extensions
{
    public static class UIConverters
    {
        public static readonly MudBlazor.Converter<DateOnly> DateOnlyConverter = new()
        {
            SetFunc = value => value.ToShortDateString(),
            GetFunc = text => DateOnly.Parse(text ?? "", CultureInfo.InvariantCulture)
        };
    }
}
