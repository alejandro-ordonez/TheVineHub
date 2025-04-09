using MudBlazor;

namespace JMMinistry.Web.Shared.Converters
{
    public class TimeOnlyConverter: Converter<TimeOnly>
    {
        public TimeOnlyConverter()
        {
            SetFunc = ConvertToString;
            GetFunc = ConvertFromString;
            Format = "HH:mm:ss";
        }

        protected virtual TimeOnly ConvertFromString(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return default;

            try
            {
                return TimeOnly.ParseExact(value, Format ?? Culture.DateTimeFormat.ShortDatePattern, Culture);
            }
            catch (FormatException ex)
            {
                UpdateGetError(ex.ToString());
                return default;
            }
        }


        protected virtual string ConvertToString(TimeOnly arg)
        {
            return arg.ToString(Format);
        }
    }
}
