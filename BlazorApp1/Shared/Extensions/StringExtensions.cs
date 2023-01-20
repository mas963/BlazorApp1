using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNull(this Guid value)
        {
            return value == null || value == Guid.Empty;
        }

        public static bool IsNull(this Guid? value)
        {
            return value == null || !value.HasValue || value == Guid.Empty;
        }

        public static string SafeSubstring(this string text, int start, int lenght)
        {
            return text.Length <= start ? ""
                : text.Length - start <= lenght ? text.Substring(start)
                : text.Substring(start, lenght);
        }

        public static string SafeSubstring(this string text, int lenght)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return text.Length <= lenght ? text : text.Substring(0, lenght);
        }
    }
}
