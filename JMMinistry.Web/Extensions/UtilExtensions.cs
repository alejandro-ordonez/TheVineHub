using JMMinistry.Common.Dtos.User.Enums;
using MudBlazor;

namespace JMMinistry.Web.Extensions
{
    public static class UtilExtensions
    {
        public static byte[] ParseBase64WithoutPadding(this string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public static string GetGenderIcon(this Gender gender) =>
            gender switch
            {
                Gender.Male => Icons.Material.Filled.Male,
                Gender.Female => Icons.Material.Filled.Female,
                _ => Icons.Material.Filled.Man
            };


        public static Color GetGenderColor(this Gender gender) =>
            gender switch
            {
                Gender.Male => Color.Primary,
                Gender.Female or _ => Color.Secondary
            };

        public static Color GetRandomColor()
        {
            return (Color)Random.Shared.Next(7);
        }
    }
}
