using System;
using System.Collections.Generic;
using System.Data;
using Media_Bazaar_Logic.Enums;

namespace Media_Bazaar_Logic.DAL
{
    public static class ContractDAL
    {


        public static void AddNewContract(int userid, ContractType contractid, double hourrate, DateTime startdate, DateTime enddate)
        {

            string sql = "INSERT INTO `employeecontract` (`EmployeeID`,`ContractID`,`HourRate`,`StartDate`,`EndDate`)" +
                              "VALUES (@EmployeeID,@ContractID,@HourRate,@StartDate,@EndDate)";





            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("EmployeeID", userid),
                  new KeyValuePair<string, dynamic>("ContractID", contractid),
                  new KeyValuePair<string, dynamic>("HourRate", hourrate),
                  new KeyValuePair<string, dynamic>("StartDate", startdate),
                  new KeyValuePair<string, dynamic>("EndDate", enddate),


                };


            DatabaseController.ExecuteInsert(sql, parameters);


        }


        public static DataSet GetContractByID(int id)
        {

            try
            {
                string sql = "SELECT * FROM employeecontract WHERE EmployeeID = @EmployeeID";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("EmployeeID", id),

                };

                DataSet d = DatabaseController.ExecuteSql(sql, parameters);
                return d;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static void TerminateContractByID(int id,DateTime date,DateTime latestdate)
        {

            string sql = "UPDATE `employeecontract` SET EndDate = @EndDate WHERE `EmployeeID` = @EmployeeID AND `StartDate` = @StartDate";





            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("EmployeeID", id),
                  new KeyValuePair<string, dynamic>("EndDate", date),
                  new KeyValuePair<string, dynamic>("StartDate", latestdate),



                };


            DatabaseController.ExecuteInsert(sql, parameters);



        }
    }
}
