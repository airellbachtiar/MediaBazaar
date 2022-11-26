using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Media_Bazaar_Website.ClassCollection.UserCollection
{
    public class UserSchedule
    {
        public int Id { get; }
        public int WeekNumber { get; set; }
        public int Day { get; set; }
        public string Shift { get; set; }

        public DateTime Date{ get; set; }

        public UserSchedule(int id, int weekNumber, int day, string shift)
        {
            Id = id;
            WeekNumber = weekNumber;
            Day = day;
            Shift = shift;
        }
    }
}
