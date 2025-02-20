using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common
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
    }
}
