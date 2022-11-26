using System.Collections.Generic;
using System.Data;
using Media_Bazaar_Logic.Enums;

namespace Media_Bazaar_Logic.Parsers
{
    public static class ScheduleParser
    {
        public static List<List<string>> GetSchedule(DataSet data)
        {
            List<List<string>> schedule = new List<List<string>>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                string userID = data.Tables[0].Rows[row]["EmployeeID"].ToString();
                string day = data.Tables[0].Rows[row]["Day"].ToString();
                string shifts = data.Tables[0].Rows[row]["Shift"].ToString();

                List<string> scheduleToAdd = new List<string> { userID, day, shifts };

                schedule.Add(scheduleToAdd);
            }
            return schedule;
        }

        public static List<KeyValuePair<string, dynamic>> AddEmployeeShift(int userID, int week, Day day, string shift, int department)
        {
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("userID", userID),
                new KeyValuePair<string, dynamic>("weekNumber", week),
                new KeyValuePair<string, dynamic>("shiftDay", day),
                new KeyValuePair<string, dynamic>("shift", shift),
                new KeyValuePair<string, dynamic>("department", department)
            };

            return parameters;
        }

        public static List<KeyValuePair<string, dynamic>> RemoveEmployeeShift(int userID, int week, Day day, int department)
        {
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("userID", userID),
                new KeyValuePair<string, dynamic>("weekNumber", week),
                new KeyValuePair<string, dynamic>("shiftDay", day),
                new KeyValuePair<string, dynamic>("department", department)
            };

            return parameters;
        }

        public static List<KeyValuePair<string, dynamic>> ChangeShift(int userID, int week, Day day, int department, List<string> shifts)
        {
            string shift = shifts[0];
            for(int i = 1; i < shifts.Count; i++)
            {
                shift += $",{shifts[i]}";
            }

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("userID", userID),
                new KeyValuePair<string, dynamic>("weekNumber", week),
                new KeyValuePair<string, dynamic>("shiftDay", day),
                new KeyValuePair<string, dynamic>("department", department),
                new KeyValuePair<string, dynamic>("shift", shift)
            };

            return parameters;

        }

        public static List<List<string>> GetEmpAvailability(DataSet data)
        {
            List<List<string>> availability = new List<List<string>>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                List<string> empAvail = new List<string>();
                empAvail.Add(data.Tables[0].Rows[row]["empID"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["contractID"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Monday"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Tuesday"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Wednesday"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Thursday"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Friday"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Saturday"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Sunday"].ToString());
                
                availability.Add(empAvail);
            }

            return availability;
        }

        public static List<KeyValuePair<string, dynamic>> AddUserAvail(int userID, int contractID)
        {
            int contractHour = -1;
            switch (contractID)
            {
                case 1:
                    contractHour = 40;
                    break;
                case 2:
                    contractHour = 24;
                    break;
                case 3:
                    contractHour = 0;
                    break;
            }

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("userID", userID),
                new KeyValuePair<string, dynamic>("contractID", contractHour),
                new KeyValuePair<string, dynamic>("isAvail", "true")
            };

            return parameters;
        }
    }
}
