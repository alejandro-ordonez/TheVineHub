using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;
using JMMinistry.Application.Features.User.Enums;

namespace JMMinistry.Application.Common
{
    public static class CommonExtensions
    {
        public static string ToCapitalCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            var values = str.Split(' ');
            var words = new List<string>();

            foreach (var value in values)
            {
                var trimmed = value.Trim().ToLower();
                words.Add($"{char.ToUpper(trimmed[0])}{trimmed[1..]}");
            }

            return string.Join(" ", words);
        }

        public static int YearsElapsed(this DateOnly date)
        {
            var today = DateTime.Today;
            var dateTime = date.ToDateTime(TimeOnly.MinValue);
            var years = today.Year - dateTime.Year;

            if (dateTime > today.AddYears(-years))
                years--;

            return years;
        }

        public static bool IsAdminOrLeader(this AccessType accessType) => accessType switch
        {
            AccessType.Admin or AccessType.Leader => true,
            _ => false
        };
    }
}
