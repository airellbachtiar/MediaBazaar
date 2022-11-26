using Media_Bazaar_Logic.Enums;
using Contract = Media_Bazaar_Logic.Class.Contract;

namespace Media_Bazaar_Logic.Class
{
    public class User
    {


        // Contract is comented for testing purposes. Ismet
        // added Id parameter inside the constructor to get the id from the database.
        private int id;
        private string firstName;
        private string surName;
        private string userName;
        private string password;
        private long phoneNumber;
        private long contactPerson; //phone number for emergency contact
        private string email;
        private long bSN;
        private string job; //idk
        private RoleType role;
        private Contract contract;
        private int department;
        private string note;
        private bool isActive; //indicates wether the employee is still with the company

        public User()
        {

        }

        public User(int id,string firstname,string surname,string username,string password, long phonenumber, long contactperson,string email, long bsn,string job,RoleType role,int department,string note)
        {
            this.id = id;
            this.firstName = firstname;
            this.surName = surname;
            this.userName = username;
            this.password = password;
            this.phoneNumber = phonenumber;
            this.contactPerson = contactperson;
            this.email = email;
            this.bSN = bsn;
            this.job = job;
            this.department = department;
            this.role = role;
            //this.contract = contract;
            this.note = note;
            //this.isActive = isactive;
        }

        public int ID
        {
            get { return this.id; }
        }
        public string FirstName
        {
            get { return this.firstName; }
        }
        public string SurName
        {
            get { return this.surName; }
        }
        public string UserName
        {
            get { return this.userName; }
        }
        public string Password
        {
            get { return this.password; }
        }
        public long PhoneNumber
        {
            get { return this.phoneNumber; }
        }

        public int Department
        {
            get { return this.department; }
        }

        public long ContactPerson
        {
            get { return this.contactPerson; }
        }
        public string Email
        {
            get { return this.email; }
        }
        public long BSN
        {
            get { return this.bSN; }
        }
        public string Job
        {
            get { return this.job; }
        }
        public RoleType Role
        {
            get { return this.role; }
        }
        public Contract Contract
        {
            get { return this.contract; }
        }
        public string Note
        {
            get { return this.note; }
        }
        public bool IsActive
        {
            get { return this.isActive; }
        }



    }
}
