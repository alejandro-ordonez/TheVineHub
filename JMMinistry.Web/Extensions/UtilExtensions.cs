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
    }
}
