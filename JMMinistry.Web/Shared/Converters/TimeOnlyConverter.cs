using MudBlazor;

namespace JMMinistry.Web.Shared.Converters
{
    public class TimeOnlyConverter : IConverter<TimeOnly, string>
    {
        private const string DefaultFormat = "HH:mm:ss";

        public string Convert(TimeOnly value)
        {
            return value.ToString(DefaultFormat);
        }

        public TimeOnly ConvertBack(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return default;

            if (TimeOnly.TryParseExact(value, DefaultFormat, null, System.Globalization.DateTimeStyles.None, out var result))
                return result;

            return default;
        }
    }
}
