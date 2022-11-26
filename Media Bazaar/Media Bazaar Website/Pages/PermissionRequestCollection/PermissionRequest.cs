using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Media_Bazaar_Website.Pages.PermissionRequestCollection
{
    public class PermissionRequest
    {
        private int id;
        private DateTime sentDate;
        private int employeeID;
        private string message;
        private string type;
        private DateTime? startDate;
        private DateTime? endDate;
        private bool? isApproved;

        public PermissionRequest(int id, DateTime sentDate, int employeeID, string message, string type, DateTime? startDate, DateTime? endDate, bool? isApproved)
        {
            this.Id = id;
            this.SentDate = sentDate;
            this.EmployeeID = employeeID;
            this.Message = message;
            this.Type = type;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.isApproved = isApproved;
        }

        public int Id { get { return id; } set { id = value; } }
        public DateTime SentDate { get { return sentDate; } set { sentDate = value; } }
        public int EmployeeID { get { return employeeID; } set { employeeID = value; } }
        public string Message { get { return message; } set { message = value; } }
        public string Type { get { return type; } set { type = value; } }
        public DateTime? StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime? EndDate { get { return endDate; } set { endDate = value; } }
        public bool? IsApproved { get { return isApproved; } set { isApproved = value; } }
    }
}
