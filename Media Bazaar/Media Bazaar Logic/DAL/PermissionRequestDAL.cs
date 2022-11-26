using System;
using System.Collections.Generic;
using System.Data;
using Media_Bazaar_Logic.Class.PermissionRequestCollection;

namespace Media_Bazaar_Logic.DAL
{
    public class PermissionRequestDAL
    {
        public static DataSet GetAllPermissionRequests()
        {
            try
            {
                string sql = "SELECT * FROM permissionrequest";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>();
                DataSet result = DatabaseController.ExecuteSql(sql, parameters);

                return result;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static DataSet GetIsApprovedFilterPermissionRequest(bool? input)
        {
            string sql = "SELECT * FROM permissionrequest WHERE IsApproved = @IsApproved";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("IsApproved", input)
            };
            return DatabaseController.ExecuteSql(sql, parameters);
        }

        public static DataSet GetUserPermissionRequests(int employeeID)
        {
            string sql = "SELECT * FROM permissionrequest WHERE EmployeeID = @EmployeeID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("EmployeeID", employeeID)
            };
            return DatabaseController.ExecuteSql(sql, parameters);
        }

        public static DataSet GetSpecificPermissionRequest(int id, int employeeID)
        {
            string sql = "SELECT * FROM permissionrequest WHERE ID = @ID AND EmployeeID = @EmployeeID";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("ID", id),
                new KeyValuePair<string, dynamic>("EmployeeID", employeeID)
            };
            return DatabaseController.ExecuteSql(sql, parameters);
        }

        public static bool AddNewPermissionRequest(PermissionRequest permissionRequest)
        {
            try
            {
                string sql = "INSERT INTO `permissionrequest` (`ID`, `EmployeeID`, `SentDate`, `Message`, `Type`, `StartDate`, `EndDate`, `IsApproved`) VALUES (@ID, @EmployeeID, current_timestamp(), @Message, @Type, @StartDate, @EndDate, NULL)";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("ID", permissionRequest.Id),
                new KeyValuePair<string, dynamic>("EmployeeID", permissionRequest.EmployeeID),
                new KeyValuePair<string, dynamic>("Message", permissionRequest.Message),
                new KeyValuePair<string, dynamic>("Type", permissionRequest.Type),
                new KeyValuePair<string, dynamic>("StartDate", permissionRequest.StartDate),
                new KeyValuePair<string, dynamic>("EndDate", permissionRequest.EndDate)
            };
                DatabaseController.ExecuteInsert(sql, parameters);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool UpdateApprovalInPermissionRequest(PermissionRequest permissionRequest)
        {
            try
            {
                string sql = "UPDATE `permissionrequest` SET IsApproved = @IsApproved WHERE ID = @ID AND EmployeeID = @EmployeeID";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new KeyValuePair<string, dynamic>("IsApproved", permissionRequest.IsApproved),
                    new KeyValuePair<string, dynamic>("ID", permissionRequest.Id),
                    new KeyValuePair<string, dynamic>("EmployeeID", permissionRequest.EmployeeID)
                };
                DatabaseController.ExecuteInsert(sql, parameters);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
