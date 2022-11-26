using System.Collections.Generic;
using System.Data;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.DAL;
using Media_Bazaar_Logic.Enums;
using Media_Bazaar_Logic.Parsers;

namespace Media_Bazaar_Logic.Controllers
{
    public class SchedulerController
    {
        private static DataSet data;

        // Get the schedule for the week
        public static List<List<string>> GetSchedule(int week, int department)
        {
            data = SchedulerDAL.GetSchedule(week, department);
            return ScheduleParser.GetSchedule(data);
        }

        // Adding an employee to a certain shift
        public static void AddEmployeeShift(User user, int weekNumber, Day day, string shift, int department)
        {
            List<KeyValuePair<string, dynamic>> parameters = ScheduleParser.AddEmployeeShift(user.ID, weekNumber, day, shift, department);
            SchedulerDAL.AddEmployeeShift(parameters);
        }

        // Removing an employee from a shift
        public static void RemoveEmployeeShift(User user, int weekNumber, int department, Day day)
        {
            List<KeyValuePair<string, dynamic>> parameters = ScheduleParser.RemoveEmployeeShift(user.ID, weekNumber, day, department);
            SchedulerDAL.RemoveEmployeeShift(parameters);
        }

        // Changing the shift of an employee
        public static void ChangeShift(User user, int weekNumber, Day day, int department, List<string> shifts)
        {
            List<KeyValuePair<string, dynamic>> parameters = ScheduleParser.ChangeShift(user.ID, weekNumber, day, department, shifts);
            SchedulerDAL.ChangeShift(parameters);
        }

        // Getting the availability from the employees
        public static List<List<string>> GetEmpAvailability()
        {
            data = SchedulerDAL.GetEmpAvailability();
            return ScheduleParser.GetEmpAvailability(data);
        }

        public static void AddUserAvail(int userID, int contractId)
        {
            List<KeyValuePair<string, dynamic>> parameters = ScheduleParser.AddUserAvail(userID, contractId);
            SchedulerDAL.AddUserAvail(parameters);
        }
    }
}
