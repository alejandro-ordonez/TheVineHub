using MudBlazor;

namespace JMMinistry.Web.Shared.Converters
{
    public class DateOnlyConverter : IConverter<DateOnly, string>
    {
        private const string DefaultFormat = "yyyy-MM-dd";

        public string Convert(DateOnly value)
        {
            return value.ToString(DefaultFormat);
        }

        public DateOnly ConvertBack(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return default;

            if (DateOnly.TryParseExact(value, DefaultFormat, null, System.Globalization.DateTimeStyles.None, out var result))
                return result;

            return default;
        }
    }
}
