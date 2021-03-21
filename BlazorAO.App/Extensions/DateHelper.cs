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

        
    }
}
