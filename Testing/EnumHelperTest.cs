using BlazorAO.App.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing
{
    [TestClass]
    public class EnumHelperTest
    {
        [TestMethod]
        public void ToDictionary()
        {
            var weekDays = EnumHelper.ToDictionary<DayOfWeek>();
            Assert.IsTrue(weekDays.SequenceEqual(new KeyValuePair<int, string>[]
            {
                new KeyValuePair<int, string>(0, "Sunday"),
                new KeyValuePair<int, string>(1, "Monday"),
                new KeyValuePair<int, string>(2, "Tuesday"),
                new KeyValuePair<int, string>(3, "Wednesday"),
                new KeyValuePair<int, string>(4, "Thursday"),
                new KeyValuePair<int, string>(5, "Friday"),
                new KeyValuePair<int, string>(6, "Saturday")                
            }));
        }

        [TestMethod]
        public void SqlServerWeekDays()
        {
            var weekDays = EnumHelper.SqlServerWeekDays();
            Assert.IsTrue(weekDays.SequenceEqual(new KeyValuePair<int, string>[]
            {
                new KeyValuePair<int, string>(1, "Sunday"),
                new KeyValuePair<int, string>(2, "Monday"),
                new KeyValuePair<int, string>(3, "Tuesday"),
                new KeyValuePair<int, string>(4, "Wednesday"),
                new KeyValuePair<int, string>(5, "Thursday"),
                new KeyValuePair<int, string>(6, "Friday"),
                new KeyValuePair<int, string>(7, "Saturday")
            }));
        }
    }
}
