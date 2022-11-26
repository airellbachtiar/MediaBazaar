using System;
using System.Collections.Generic;
using System.Data;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.DAL;
using Media_Bazaar_Logic.Enums;
using Media_Bazaar_Logic.Parsers;

namespace Media_Bazaar_Logic.Controllers
{
    public class UserController
    {
   

        


        public static List<User> GetAllUsers()
        {
            DataSet d = EmployeeDAL.GetAllEmployees();
            List<User> list = new List<User>();

            for (int x = 0; x < d.Tables[0].Rows.Count; x++)
            {
                User p = UserParser.DataSetToUser(d, x);
                list.Add(p);
            }
            return list;
        }

        public static List<User> GetAllActiveUsersByDepartment(int depid)
        {
            DataSet d = EmployeeDAL.GetAllActiveUsersByDepartment(depid);
            List<User> list = new List<User>();

            for (int x = 0; x < d.Tables[0].Rows.Count; x++)
            {
                User p = UserParser.DataSetToUser(d, x);
                list.Add(p);
            }
            return list;
        }


        public static List<User> GetAllInActiveUsersByDepartment(int depid)
        {
            DataSet d = EmployeeDAL.GetAllInActiveUsersByDepartment(depid);
            List<User> list = new List<User>();

            for (int x = 0; x < d.Tables[0].Rows.Count; x++)
            {
                User p = UserParser.DataSetToUser(d, x);
                list.Add(p);
            }
            return list;
        }

        public static void CreateNewUser(string firstname, string surname, string username, string password, int phonenumber, int contactperson, string email, int bsn, RoleType role, string job, int department, string note)
        {
            EmployeeDAL.AddNewUser(firstname, surname, username, PasswordHashingHelper.StringToHash(password), phonenumber, contactperson, email, bsn, role, job, department, note);

            

        }

        public static void EditUser(int BSN,int phone,int contact,string email,string function,string notes,int department)
        {
            EmployeeDAL.UpdateUser(BSN, phone, contact, email, function, notes,department);
        }


        public static User Login(string username,string password)
        {
            DataSet d = EmployeeDAL.Login(username, PasswordHashingHelper.StringToHash(password));
            if (d.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            
            User user = UserParser.DataSetToUser(d, 0);

            return user;
        }

        public static User GetUserByBSN(int BSN)
        {
            return UserParser.DataSetToUser(EmployeeDAL.GetUserByBSN(BSN), 0);
        }

        public static User GetUserByID(int id)
        {
            try
            {
                return EmployeeDAL.GetUserById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void UpdateProfile(int id,long phone, long contact,string surname)
        {
            EmployeeDAL.UpdateProfile(id,phone, contact, surname);
        }

        public static void UpdatePassword(int id,string password)
        {
            EmployeeDAL.UpdatePassword(id, PasswordHashingHelper.StringToHash(password));
        }

        public static bool EditUserInWebsite(int id, string username, string surname, string email, int phoneNumber, int contactPerson)
        {
            try
            {
                EmployeeDAL.UpdateUserInWebsite(id, username, surname, email, phoneNumber, contactPerson);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
