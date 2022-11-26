using System;
using System.Data;
using Media_Bazaar_Logic.Class.PermissionRequestCollection;

namespace Media_Bazaar_Logic.Parsers
{
    public static class PermissionRequestParser
    {
        public static PermissionRequest DataSetToPermissionRequest(DataSet table, int row)
        {
            int id = Convert.ToInt32(table.Tables[0].Rows[row]["ID"]);
            DateTime sentDate = DateTime.Parse(table.Tables[0].Rows[row]["SentDate"].ToString());
            int employeeID = Convert.ToInt32(table.Tables[0].Rows[row]["EmployeeID"]);
            string message = table.Tables[0].Rows[row]["Message"].ToString();
            string type = table.Tables[0].Rows[row]["Type"].ToString();
            DateTime? startDate = ParserOptions.DateTimeConverterFromDBToClass(table.Tables[0].Rows[row]["StartDate"].ToString());
            DateTime? endDate = ParserOptions.DateTimeConverterFromDBToClass(table.Tables[0].Rows[row]["EndDate"].ToString());
            bool? isApproved = ParserOptions.BooleanConverterFromDBToClass(table.Tables[0].Rows[row]["IsApproved"].ToString());

            PermissionRequest permissionRequest = new PermissionRequest(id, sentDate, employeeID, message, type, startDate, endDate, isApproved);
            return permissionRequest;
        }
    }
}
