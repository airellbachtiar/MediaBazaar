using Media_Bazaar_Logic.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_Website.ClassCollection.DAL
{
    public static class SchedulerDAL
    {
        public static DataSet GetSchedule()
        {
            try
            {
                string sql = "SELECT * FROM schedule";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {

                };

                return DatabaseController.ExecuteSql(sql, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddEmployeeShift(List<KeyValuePair<string, dynamic>> parameters)
        {
            try
            {
                string sql = "INSERT INTO schedule(`EmployeeID`, `WeekNumber`, `Day`, `Shift`) VALUES(@userID, @weekNumber, '@shiftDay', '@shiftTime')";
                DatabaseController.ExecuteInsert(sql, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void RemoveEmployeeShift(List<KeyValuePair<string, dynamic>> parameters)
        {
            try
            {
                string sql = "DELETE FROM schedule WHERE `EmployeeID` = @userID && `WeekNumber` = @weekNumber && `Day` = '@shiftDay' && `Shift` = `@shiftTime`";
                DatabaseController.ExecuteInsert(sql, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetEmpAvailability()
        {
            try
            {
                string sql = "SELECT * FROM empavailability";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {

                };

                return DatabaseController.ExecuteSql(sql, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
