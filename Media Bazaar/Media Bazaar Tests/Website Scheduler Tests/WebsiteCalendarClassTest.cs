using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Media_Bazaar_Tests.Website_Scheduler_Tests
{
    [TestClass]
    public class WebsiteCalendarClassTest
    {
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        public List<DateTime> WeekDate { get; set; }

        [TestMethod]
        public void GenerateDateOfWeek_ReturnListOfDate()
        {
            SetupWeekDate(DateTime.Now.AddDays(-2));

            foreach (DateTime d in WeekDate)
            {
                TestContext.WriteLine(d.ToString());
            }
        }

        private void SetupWeekDate(DateTime date)
        {
            //Get first day of week
            DateTime output = new DateTime();
            for (int i = 0; i < 7; i++)
            {
                DateTime temp = date.AddDays(i);
                if (date.AddDays(i).DayOfWeek == DayOfWeek.Saturday)
                {
                    output = temp.AddDays(-6);
                }
            }

            //Get the whole week
            List<DateTime> dateTimes = new List<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                dateTimes.Add(output.AddDays(i));
            }
            WeekDate = dateTimes;
        }

        [TestMethod]
        public void GenerateDateOfWeekFromWeekNumber_ReturnListOfDate()
        {
            SetupWeekDate(DateTime.Now.AddDays(-2));

            TestContext.WriteLine(GetDateFromWeekNumberAndDayOfWeek(53, 7).ToString());
        }

        private DateTime GetDateFromWeekNumberAndDayOfWeek(int weekNumber, int dayOfWeek)
        {
            DateTime jan1 = new DateTime(DateTime.Now.Year, 1, 1);

            DateTime weekFromWeekNumber = jan1.AddDays((weekNumber - 1) * 7);

            SetupWeekDate(weekFromWeekNumber);

            DateTime result = DateTime.Now;

            return WeekDate[0].AddDays(dayOfWeek);
        }
    }
}
