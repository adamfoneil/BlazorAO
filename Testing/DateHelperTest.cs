using BlazorAO.App.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class DateHelperTest
    {
        [TestMethod]
        public void FirstOfTests()
        {
            // this week
            Assert.IsTrue(new DateTime(2021, 3, 21).FirstAfter(DayOfWeek.Monday).Equals(new DateTime(2021, 3, 22)));

            // wrap to next week
            Assert.IsTrue(new DateTime(2021, 3, 24).FirstAfter(DayOfWeek.Tuesday).Equals(new DateTime(2021, 3, 30)));
        }
    }
}
