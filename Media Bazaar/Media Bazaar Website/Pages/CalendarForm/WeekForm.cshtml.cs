using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using Media_Bazaar_Website.ClassCollection.UserCollection;
using Media_Bazaar_Website.ClassCollection.Parser;
using Media_Bazaar_Website.ClassCollection.DAL;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;

namespace Media_Bazaar_Website.Pages
{
    public class WeekFormModel : PageModel
    {
        public User user { get; set; }

        //GetDate From Selected
        [BindProperty(SupportsGet = true)]
        public string Month { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Year { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Day { get; set; }
        //Convert to DateTime from selected date
        [BindProperty, DataType(DataType.Date)]
        public DateTime Date { get; set; }

        //From previous field, get week number and arary of date
        public int WeekNumber { get; set; }
        public List<DateTime> WeekDate { get; set; }

        public List<UserSchedule> Schedules { get; set; } = new List<UserSchedule>();
        
        public JulianCalendar Calendar { get; set; }

        public void OnGet(string date)
        {
            if (date == null)
            {
                Month = DateTime.Now.Month.ToString();
                Year = DateTime.Now.Year.ToString();
                Day = DateTime.Now.Day.ToString();
                Date = new DateTime(Convert.ToInt32(Year), Convert.ToInt32(Month), Convert.ToInt32(Day));
                //WeekNumber = Calendar.GetWeekOfYear(Date, DateTimeFormatInfo.CurrentInfo.CalendarWeekRule, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
                WeekDate = SetupWeekDate(Date);
            }
            else
            {
                string[] dateSplit = date.Split("-");
                Month = dateSplit[1];
                Year = dateSplit[0];
                Day = dateSplit[2];
                Date = new DateTime(Convert.ToInt32(Year), Convert.ToInt32(Month), Convert.ToInt32(Day));
                //WeekNumber = Calendar.GetWeekOfYear(Date, DateTimeFormatInfo.CurrentInfo.CalendarWeekRule, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
                WeekDate = SetupWeekDate(Date);
            }

            if (User.Identity.IsAuthenticated)
            {
                user = UserController.GetUserByID(Convert.ToInt32(Request.Cookies["UserID"]));
                List<UserSchedule> temp = ScheduleParser.GetSchedule(SchedulerDAL.GetSchedule());

                foreach (UserSchedule s in temp)
                {
                    if(s.Id == user.ID)
                    {
                        s.Date = GetDateFromWeekNumberAndDayOfWeek(s.WeekNumber, s.Day);
                        Schedules.Add(s);
                    }
                }
            }

            /*if (CurrentMonth.ToString() == null || CurrentYear.ToString() == null)
            {
                CurrentMonth = DateTime.Now.Month;
                CurrentYear = DateTime.Now.Year;
            }
            else
            {
                *//*string[] date = ViewData["CurrentDate"].ToString().Split(" ");
                CurrentYear = Convert.ToInt32(date[0]);
                CurrentMonth = Convert.ToInt32(date[1]);*//*
            }*/

        }

        public IActionResult OnPost()
        {
            string[] date = Date.ToString("yyyy MM dd").Split(" ");
            string month = date[0];
            string year = date[1];
            string day = date[2];
            return Redirect($"/Calendar/CalendarForm?Month={Month.ToString()}");
        }

        private List<DateTime> SetupWeekDate(DateTime date)
        {
            //Get first day of week
            DateTime output = new DateTime();
            for (int i = 0; i < 7; i++)
            {
                DateTime temp = date.AddDays(i);
                if (date.AddDays(i).DayOfWeek == DayOfWeek.Saturday)
                {
                    output = temp.AddDays(-5);
                }
            }

            //Get the whole week
            List<DateTime> dateTimes = new List<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                dateTimes.Add(output.AddDays(i));
            }
            return dateTimes;
        }

        private DateTime GetDateFromWeekNumberAndDayOfWeek(int weekNumber, int dayOfWeek)
        {
            List<DateTime> dateTimes = new List<DateTime>();

            DateTime jan1 = new DateTime(DateTime.Now.Year, 1, 1);

            DateTime weekFromWeekNumber = jan1.AddDays((weekNumber - 1) * 7);

            dateTimes = SetupWeekDate(weekFromWeekNumber);

            DateTime result = DateTime.Now;

            return dateTimes[0].AddDays(dayOfWeek);
        }
    }
}
