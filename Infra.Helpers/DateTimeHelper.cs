using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers
{
    public static class DateTimeHelper
    {
        const string locale = "pt-BR";

        public static DateTime ConvertToDateTime(this string value)
        {
            var culture = CultureInfo.CreateSpecificCulture(locale);
            var styles = DateTimeStyles.AssumeLocal;
            DateTime result;
            DateTime.TryParse(value, culture, styles, out result);
            return result;
        }

        public static DateTime? ConvertToDateTimeNullable(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var culture = CultureInfo.CreateSpecificCulture(locale);
                var styles = DateTimeStyles.AssumeLocal;
                DateTime result;
                DateTime.TryParse(value, culture, styles, out result);
                return result;
            }
            else
                return null;
        }

        public static DateTime ConvertTimeToDateTime(this string time)
        {
            var result = DateTime.ParseExact(time, "H:mm", null, System.Globalization.DateTimeStyles.None);
            return result;
        }

        public static string ConvertToDateString(this DateTime? value)
        {
            var result = value != null ? ((DateTime)value).ToString("dd/MM/yyyy") : "";
            return result;
        }

        public static string ConvertToTimeString(this DateTime? value)
        {
            var result = value != null ? ((DateTime)value).ToString("HH:mm:ss") : "";
            return result;
        }

        public static string ConvertToDateTimeString(this DateTime? value)
        {
            var result = value != null ? ((DateTime)value).ToString("dd/MM/yyyy HH:mm:ss") : "";
            return result;
        }

        public static string ConvertToDateString(this DateTime value)
        {
            var result = value != null ? value.ToString("dd/MM/yyyy") : "";
            return result;
        }

        public static string ConvertToTimeString(this DateTime value)
        {
            var result = value != null ? value.ToString("HH:mm") : "";
            return result;
        }

        public static string ConvertToTimeStringHHmmss(this DateTime value)
        {
            var result = value != null ? value.ToString("HH:mm:ss") : "";
            return result;
        }

        public static string ConvertToTimeStringHHmmss(this DateTime? value)
        {
            var result = value != null ? ((DateTime)value).ToString("HH:mm:ss") : "";
            return result;
        }

        public static string ConvertToTimeString(this TimeSpan value)
        {
            var result = value != null ? value.ToString("HH:mm:ss") : "";
            return result;
        }

        public static string ConvertToDateTimeString(this DateTime value)
        {
            var result = value != null ? value.ToString("dd/MM/yyyy HH:mm:ss") : "";
            return result;
        }

        public static DateTime ConvertToDateTime(string date, string time)
        {
            var result = DateTime.Parse(date).Add(TimeSpan.Parse("0." + time));

            return result;
        }

        public static DateTime? ConvertToDateTimeNullable(string date, string time)
        {
            DateTime? result = null;
            if (!string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(time))
                result = DateTime.Parse(date).Add(TimeSpan.Parse("0." + time));

            return result;
        }

        public static TimeSpan ConvertToTimeSpan(this string time)
        {
            var result = TimeSpan.Parse("0." + time);
            return result;
        }

        public static string ConvertToForecast(this DateTime value)
        {
            string result = value.ConvertToDateTimeString();
            TimeSpan interval = DateTime.Now.Subtract(value);

            string verb = interval.TotalSeconds >= 0 ? "Há" : "Daqui";
            string adverb = interval.TotalSeconds >= 0 ? "atrás" : "";


            if (Math.Abs(interval.TotalMinutes) < 2)
                result = "Agora";
            else
                if (Math.Abs(interval.TotalSeconds) < 60)
                result = $"{verb} {Math.Truncate((Math.Abs(interval.TotalSeconds)))} segundos {adverb}";
            else
                    if (Math.Abs(interval.TotalMinutes) < 2)
                result = $"{verb} {Math.Truncate((Math.Abs(interval.TotalMinutes)))} minuto {adverb}";
            else
                        if (Math.Abs(interval.TotalMinutes) < 60)
                result = $"{verb} {Math.Truncate((Math.Abs(interval.TotalMinutes)))} minutos {adverb}";
            else
                            if (Math.Abs(interval.TotalHours) < 2)
                result = $"{verb} {Math.Truncate((Math.Abs(interval.TotalHours)))} hora {adverb}";
            else
                                if (Math.Abs(interval.TotalHours) < 24)
                result = $"{verb} {Math.Truncate((Math.Abs(interval.TotalHours)))} horas {adverb}";
            else
                                    if (Math.Abs(interval.TotalDays) < 2)
                result = $"{verb} {Math.Truncate((Math.Abs(interval.TotalDays)))} dia {adverb}";

            return result;
        }
    }
}
