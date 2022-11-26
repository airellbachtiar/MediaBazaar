using System;
using System.Collections.Generic;
using System.Data;
using Media_Bazaar_Logic.DAL;
using Media_Bazaar_Logic.Parsers;

namespace Media_Bazaar_Logic.Class.PermissionRequestCollection
{
    public static class PermissionRequestController
    {
        public static List<PermissionRequest> GetAllPermisionRequests()
        {
            DataSet dataSet = PermissionRequestDAL.GetAllPermissionRequests();
            return GenerateListOfPermissionRequests(dataSet);
        }

        public static List<PermissionRequest> GetUnseenPermissionRequest()
        {
            DataSet dataSet = PermissionRequestDAL.GetIsApprovedFilterPermissionRequest(null);
            return GenerateListOfPermissionRequests(dataSet);
        }

        public static List<PermissionRequest> GetUnapprovedPermissionRequest()
        {
            DataSet dataSet = PermissionRequestDAL.GetIsApprovedFilterPermissionRequest(false);
            return GenerateListOfPermissionRequests(dataSet);
        }

        public static List<PermissionRequest> GetApprovedPermissionRequest()
        {
            DataSet dataSet = PermissionRequestDAL.GetIsApprovedFilterPermissionRequest(true);
            return GenerateListOfPermissionRequests(dataSet);
        }

        public static List<PermissionRequest> GetUserPermissionRequests(int employeeID)
        {
            DataSet dataSet = PermissionRequestDAL.GetUserPermissionRequests(employeeID);
            return GenerateListOfPermissionRequests(dataSet);
        }

        public static PermissionRequest GetSpecificPermissionRequests(int id, int employeeID)
        {
            DataSet dataSet = PermissionRequestDAL.GetSpecificPermissionRequest(id, employeeID);
            return GeneratePermissionRequest(dataSet);
        }

        public static bool CreateNewPermissionRequest(int id, DateTime sentDate, int employeeID, string message, string type, DateTime? startDate, DateTime? endDate, bool? isApproved)
        {
            try
            {
                PermissionRequest permissionRequest = new PermissionRequest(id, sentDate, employeeID, message, type, startDate, endDate, isApproved);
                PermissionRequestDAL.AddNewPermissionRequest(permissionRequest);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool UpdateApprovalInPermissionRequest(int id, int employeeID, bool? isApproved)
        {
            try
            {
                PermissionRequest permissionRequest = GetSpecificPermissionRequests(id, employeeID);
                permissionRequest.IsApproved = isApproved;
                PermissionRequestDAL.UpdateApprovalInPermissionRequest(permissionRequest);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private static List<PermissionRequest> GenerateListOfPermissionRequests(DataSet dataSet)
        {
            try
            {
                List<PermissionRequest> output = new List<PermissionRequest>();

                for (int x = 0; x < dataSet.Tables[0].Rows.Count; x++)
                {
                    PermissionRequest p = PermissionRequestParser.DataSetToPermissionRequest(dataSet, x);
                    output.Add(p);
                }
                return output;
            }
            catch (Exception)
            {

                return null;
            }
        }

        private static PermissionRequest GeneratePermissionRequest(DataSet dataSet)
        {
            try
            {
                if (dataSet.Tables[0].Rows.Count > 0 || dataSet == null)
                {
                    return PermissionRequestParser.DataSetToPermissionRequest(dataSet, 0);
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
