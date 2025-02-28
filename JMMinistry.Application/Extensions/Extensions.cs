using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Extensions
{
    public static class Extensions
    {
        public static bool ExtractAndValidate<T>(this string[] values, T ordinal, out string output, IList<string> wrongFields) where T : Enum
        {
            var value = values.Extract(ordinal);
            var faulty = string.IsNullOrEmpty(value);

            if (faulty)
            {
                wrongFields.Add($"column: {Enum.GetName(typeof(T), ordinal)}");
                output = string.Empty;
                return faulty;
            }

            output = value ?? string.Empty;

            return false;
        }

        public static string? Extract<T>(this string[] values, T ordinal) where T : Enum
        {
            try
            {
                var value = values[Convert.ToInt32(ordinal)];
                var trimmedValue = value.Trim();
                return trimmedValue;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void ThrowOnError(this IdentityResult? result)
        {
            if (result == null)
                return;

            if (result.Succeeded)
                return;

            var errors = string.Join("\n", result.Errors.Select(error => $"{error.Code}: {error.Description}"));
            throw new Exception(errors);
        }

        public static string Sanitize(this string value)
        {
            return value.Trim()
                .Replace("ñ", "n")
                .Replace("á", "a")
                .Replace("é", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ú", "u");
        }

        public static DateTime? ToDateTime(this DateOnly? date)
        {
            if (!date.HasValue)
                return null;

            return date.Value.ToDateTime(TimeOnly.MinValue);
        }
    }
}
