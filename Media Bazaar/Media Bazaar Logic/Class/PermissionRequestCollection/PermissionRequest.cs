using System;

namespace Media_Bazaar_Logic.Class.PermissionRequestCollection
{
    public class PermissionRequest
    {
        public int Id { get; set;}
        public DateTime SentDate { get; set; }
        public int EmployeeID { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsApproved { get; set; }

        public PermissionRequest()
        {
            
        }
        
        public PermissionRequest(int id, DateTime sentDate, int employeeID, string message, string type, DateTime? startDate, DateTime? endDate, bool? isApproved)
        {
            this.Id = id;
            this.SentDate = sentDate;
            this.EmployeeID = employeeID;
            this.Message = message;
            this.Type = type;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.IsApproved = isApproved;
        }
    }
}
