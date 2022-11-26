namespace Media_Bazaar_Logic.Class
{
    public class Department
    {


        private int departmentID;
        private string departmentName;
        //private bool hasSchedule;
        string description;

        public Department()
        {

        }

        public Department(int departmentID, string departmentName,string description)
        {
            this.departmentID = departmentID;
            this.departmentName = departmentName;
            //this.hasSchedule = hasschedule;
            this.description = description;
        }

        public int DepartmentID
        {
            get { return this.departmentID; }
        }
        public string DepartmentName
        {
            get { return this.departmentName; }
        }

        public string Description
        {
            get { return this.description; }
        }

        //public bool HasSchedule
        //{
        //    get { return this.hasSchedule; }
        //}

    }
}
