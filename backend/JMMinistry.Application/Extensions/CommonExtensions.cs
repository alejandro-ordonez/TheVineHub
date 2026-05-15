namespace JMMinistry.Application.Extensions;

public static class CommonExtensions
{
    public static string Sanitize(this string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        return new string(input.Where(c => char.IsLetterOrDigit(c)).ToArray());
    }
}
