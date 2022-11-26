using System;
using System.Collections.Generic;
using System.Data;

namespace Media_Bazaar_Logic.DAL
{
    public class SchedulerDAL : DAL
    {
        public static DataSet GetSchedule(int week, int department)
        {
            try
            {
                string sql = "SELECT * FROM schedule where `WeekNumber` = @week && `Department` = @department";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new KeyValuePair<string, dynamic>("week", week),
                    new KeyValuePair<string, dynamic>("department", department)
                };

                return ExecuteSql(sql, parameters);
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
                string sql = "INSERT INTO schedule(`EmployeeID`, `WeekNumber`, `Day`, `Shift`, `Department`) VALUES(@userID, @weekNumber, @shiftDay, @shift, @department)";
                ExecuteInsert(sql, parameters);
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
                string sql = "DELETE FROM schedule WHERE `EmployeeID` = @userID && `WeekNumber` = @weekNumber && `Day` = @shiftDay && `Department` = @department";
                ExecuteInsert(sql, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public static void ChangeShift(List<KeyValuePair<string, dynamic>> parameters)
        {
            try
            {
                string sql = "UPDATE `schedule` SET `Shift` = @shift WHERE `EmployeeID` = @userID && `WeekNumber` = @weekNumber && `Day` = @shiftDay && `Department` = @department";
                ExecuteInsert(sql, parameters);
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

                return ExecuteSql(sql, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddUserAvail(List<KeyValuePair<string, dynamic>> parameters)
        {
            try
            {
                string sql = "INSERT INTO `empavailability`(`empID`, `contractID`, `Monday`, `Tuesday`, `Wednesday`, `Thursday`, `Friday`, `Saturday`, `Sunday`) VALUES (@userID, @contractID, @isAvail, @isAvail, @isAvail, @isAvail, @isAvail, @isAvail, @isAvail)";
                ExecuteInsert(sql, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
