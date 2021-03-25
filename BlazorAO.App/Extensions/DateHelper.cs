using System;

namespace BlazorAO.App.Extensions
{
    public static class DateHelper
    {
        public static DateTime FirstAfter(this DateTime date, DayOfWeek dayOfWeek)
        {
            int addDays = dayOfWeek - date.DayOfWeek;
            if (addDays < 0) addDays += 7;
            return date.Date.AddDays(addDays);
        }

        public static DateTime SoonestBefore(this DateTime date, DayOfWeek dayOfWeek)
        {
            int subtractDays = date.DayOfWeek - dayOfWeek;
            if (subtractDays < 0) subtractDays += 7;
            return date.Date.AddDays(subtractDays * -1);
        }

        public static string MonthName(int month, bool abbreviate) => (abbreviate) ? 
            MonthNameInner(month, "MMM") :
            MonthNameInner(month, "MMMM");

        private static string MonthNameInner(int month, string format) => new DateTime(DateTime.Today.Year, month, 1).ToString(format);
    }
}
