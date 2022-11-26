using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_Logic.DAL
{
    public static class EmployeeAvailabilityDAL
    {
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

        public static void AddUserAvail(List<KeyValuePair<string, dynamic>> parameters)
        {
            try
            {
                string sql = "INSERT INTO `empavailability`(`empID`, `contractID`, `Monday`, `Tuesday`, `Wednesday`, `Thursday`, `Friday`, `Saturday`, `Sunday`) VALUES (@userID, @contractID, @isAvail, @isAvail, @isAvail, @isAvail, @isAvail, @isAvail, @isAvail)";
                DatabaseController.ExecuteInsert(sql, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UpdateUserAvailability(List<string> availability)
        {
            try
            {
                string sql = "UPDATE `empavailability` SET `Monday`=@Monday,`Tuesday`=@Tuesday,`Wednesday`=@Wednesday,`Thursday`=@Thursday,`Friday`=@Friday,`Saturday`=@Saturday,`Sunday`=@Sunday WHERE `empID`=@empID";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new KeyValuePair<string, dynamic>("empID", availability[0]),
                    new KeyValuePair<string, dynamic>("Monday", availability[2]),
                    new KeyValuePair<string, dynamic>("Tuesday", availability[3]),
                    new KeyValuePair<string, dynamic>("Wednesday", availability[4]),
                    new KeyValuePair<string, dynamic>("Thursday", availability[5]),
                    new KeyValuePair<string, dynamic>("Friday", availability[6]),
                    new KeyValuePair<string, dynamic>("Saturday", availability[7]),
                    new KeyValuePair<string, dynamic>("Sunday", availability[8])
                };
                DatabaseController.ExecuteInsert(sql, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
