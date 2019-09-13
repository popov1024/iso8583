namespace Iso8583.Utils
{
    using System;
    using System.Globalization;

    internal class ConvertDateTime
    {
        internal static string MMDDhhmmss(DateTime dateTime)
        {
            return dateTime.ToString("MMddHHmmss", CultureInfo.InvariantCulture);
        }

        internal static DateTime MMDDhhmmss(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "MMddHHmmss", CultureInfo.InvariantCulture);
        }

        internal static string yyMM(DateTime dateTime)
        {
            return dateTime.ToString("yyMM", CultureInfo.InvariantCulture);
        }

        internal static DateTime yyMM(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "yyMM", CultureInfo.InvariantCulture);
        }

        internal static string MMDD(DateTime dateTime)
        {
            return dateTime.ToString("MMdd", CultureInfo.InvariantCulture);
        }

        internal static DateTime MMDD(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "MMdd", CultureInfo.InvariantCulture);
        }

        internal static string hhmmss(DateTime dateTime)
        {
            return dateTime.ToString("HHmmss", CultureInfo.InvariantCulture);
        }

        internal static DateTime hhmmss(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "HHmmss", CultureInfo.InvariantCulture);
        }
    }
}
