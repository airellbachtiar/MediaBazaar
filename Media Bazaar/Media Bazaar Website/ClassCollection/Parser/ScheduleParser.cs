using Media_Bazaar_Website.ClassCollection.UserCollection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_Website.ClassCollection.Parser
{
    public static class ScheduleParser
    {
        public static List<UserSchedule> GetSchedule(DataSet data)
        {
            List<UserSchedule> schedules = new List<UserSchedule>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                int id = Convert.ToInt32(data.Tables[0].Rows[row]["EmployeeID"]);
                int weekNumber = Convert.ToInt32(data.Tables[0].Rows[row]["WeekNumber"]);
                int day = Convert.ToInt32(data.Tables[0].Rows[row]["Day"]);
                string shift = data.Tables[0].Rows[row]["Shift"].ToString();
                string[] splitShift = shift.Split(',');
                for(int i = 0; i < splitShift.Count(); i++)
                {
                    schedules.Add(new UserSchedule(id, weekNumber, day-1, splitShift[i]));
                }
            }
            return schedules;
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
    }
}
