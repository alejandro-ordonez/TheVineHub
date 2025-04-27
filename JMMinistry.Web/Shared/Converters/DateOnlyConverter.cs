using MudBlazor;

namespace JMMinistry.Web.Shared.Converters
{
    public class DateOnlyConverter : Converter<DateOnly>
    {
        public DateOnlyConverter()
        {
            SetFunc = ConvertToString;
            GetFunc = ConvertFromString;
            Format = "yyyy-MM-dd";
        }

        protected virtual DateOnly ConvertFromString(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return default;

            try
            {
                return DateOnly.ParseExact(value, Format ?? Culture.DateTimeFormat.ShortDatePattern, Culture);
            }
            catch (FormatException)
            {
                UpdateGetError("Failed to parse the given date");
                return default;
            }
        }


        protected virtual string ConvertToString(DateOnly arg)
        {
            return arg.ToString(Format);
        }
    }
}
