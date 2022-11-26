using System;
using System.Collections.Generic;
using System.Data;
using Media_Bazaar_Logic.Class;

namespace Media_Bazaar_Logic.DAL
{
    public static class SickDayDAL
    {
        private static string sql;

        public static bool AddSickDay(int userId)
        {
            DateTime date = DateTime.Today;
            
            sql = $"INSERT INTO sickday VALUES(@userId, @date)";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new ("userId", userId),
                new ("date", date),
            };

            try
            {
                DatabaseController.ExecuteInsert(sql, parameters);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
        
        public static List<DateTime> GetSickDaysForUser(int userId)
        {
            sql = "SELECT * FROM sickday WHERE userId = @userId";

            List<DateTime> returnList = new List<DateTime>(); 

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new ("userId", userId)
            };
            
            try
            {
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    DateTime sickDay = (DateTime)dataSet.Tables[0].Rows[i]["date"];
                    returnList.Add(sickDay);
                }
            }
            catch (Exception)
            {
                return null;
            }

            return returnList;
        }

        /// <summary>
        /// This method returns all User items that are marked as sick in the database for the given date.
        /// </summary>
        /// <param name="date">The date to check for sick employees.</param>
        /// <returns></returns>
        public static List<User> GetSickUsersForDate(DateTime date)
        {
            sql = "SELECT * FROM `employee` RIGHT JOIN sickday ON sickday.userId = employee.ID WHERE sickday.date = @date";
            List<User> sickUsers = new List<User>();

            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new ("date", date)
                };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                for (int x = 0; x < dataSet.Tables[0].Rows.Count; x++)
                {
                    User u = Parsers.UserParser.DataSetToUser(dataSet, x);
                    sickUsers.Add(u);
                }
            }
            catch (Exception)
            {
                return null;
            }
            
            return sickUsers;
        }

        public static User GetMostSickUserAllTime()
        {
            sql = "SELECT *, COUNT(userId) AS value_occurrence FROM `sickday` GROUP BY `userId` ORDER BY value_occurrence DESC LIMIT 1";
            int userId = -1;
            
            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                { };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                userId = (int)dataSet.Tables[0].Rows[0]["userId"];
            }
            catch (Exception)
            {
                return null;
            }

            if (userId == -1)
            {
                return null;
            }

            return EmployeeDAL.GetUserById(userId);
        }
        
        public static User GetMostSickUserLast30Days()
        {
            sql = "SELECT *, COUNT(userId) AS value_occurrence FROM `sickday` WHERE date >= @dateString GROUP BY `userId` ORDER BY value_occurrence DESC LIMIT 1";
            int userId = -1;
            DateTime dateTime30DaysAgo = DateTime.Now - TimeSpan.FromDays(30);
            string dateString = dateTime30DaysAgo.Year + "" + dateTime30DaysAgo.Month + "" + dateTime30DaysAgo.Day;
            
            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new ("dateString", dateString),
                };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                userId = (int)dataSet.Tables[0].Rows[0]["userId"];
            }
            catch (Exception)
            {
                return null;
            }

            if (userId == -1)
            {
                return null;
            }

            return EmployeeDAL.GetUserById(userId);
        }

        public static long GetTotalAmountOfSickEmployees()
        {
            sql = "SELECT COUNT(userId) FROM `sickday`";
            long sickAmount = -1;
            
            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                { };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                sickAmount = (long)dataSet.Tables[0].Rows[0]["COUNT(userId)"];
            }
            catch (Exception)
            {
                return sickAmount;
            }

            return sickAmount;
        }

        public static long GetTotalAmountOfSickEmployeesLast30Days()
        {
            sql = "SELECT COUNT(userId) FROM `sickday` WHERE date >= @dateString";
            long sickAmount = -1;
            
            DateTime dateTime30DaysAgo = DateTime.Now - TimeSpan.FromDays(30);
            string dateString = dateTime30DaysAgo.Year + "" + dateTime30DaysAgo.Month + "" + dateTime30DaysAgo.Day;
            
            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new ("dateString", dateString),
                };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                sickAmount = (long)dataSet.Tables[0].Rows[0]["COUNT(userId)"];
            }
            catch (Exception)
            {
                return sickAmount;
            }

            return sickAmount;
        }
    }
}