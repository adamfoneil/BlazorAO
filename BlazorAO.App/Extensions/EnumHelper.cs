using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorAO.App.Extensions
{
    public static class EnumHelper
    {
        public static Dictionary<int, string> SqlServerWeekDays() => ToDictionary<DayOfWeek>(i => i + 1);

        public static Dictionary<int, string> ToDictionary<TEnum>(Func<int, int> transform = null)
        {
            var names = Enum.GetNames(typeof(TEnum));
            var values = Enum.GetValues(typeof(TEnum));

            return names.Select((name, index) =>
            {
                var value = Convert.ToInt32(values.GetValue(index));
                value = transform?.Invoke(value) ?? value;
                return new
                {
                    Value = value,
                    Text = name
                };
            }).ToDictionary(item => item.Value, item => item.Text);
        }
    }
}
