using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Extensions
{
    public static class DateTimeExtension
    {
        private static string emptyDateTimeStr = "00:00:00";

        public static string GetRemaningDateStr(this DateTime expireDate)
        {
            if (expireDate == null || expireDate == DateTime.MinValue)
                return emptyDateTimeStr;

            TimeSpan ts = expireDate.Subtract(DateTime.Now);

            return ts.TotalSeconds >= 0 ? ts.ToString(@"hh\:mm\:ss") : emptyDateTimeStr;
        }

        public static string ToCustomDateString(this DateTime dateTime)
        {
            return dateTime == null ? "01.01.2000" : dateTime.ToString("dd.MM.yyyy");
        }

        public static string ToCustomTimeString(this DateTime dateTime)
        {
            return dateTime == null ? "00:00" : dateTime.ToString("HH:mm");
        }

        public static string ToCustomDateTimeString(this DateTime dateTime)
        {
            return $"{dateTime.ToCustomDateString()} {dateTime.ToCustomTimeString()}";
        }

        public static bool IsNull(this DateTime dateTime)
        {
            return dateTime == null || dateTime == DateTime.MinValue;
        }

        public static bool IsNull(this DateTime? dateTime)
        {
            return !dateTime.HasValue ||IsNull(dateTime);
        }
    }
}
