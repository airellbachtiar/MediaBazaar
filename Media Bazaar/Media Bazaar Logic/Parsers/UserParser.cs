using System;
using System.Data;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Enums;

namespace Media_Bazaar_Logic.Parsers
{
    public static class UserParser
    {

        public static User DataSetToUser(DataSet table,int row)
        {
            int id = (int)table.Tables[0].Rows[row]["ID"];
            string firstname = (string)table.Tables[0].Rows[row]["FirstName"];
            string surname = (string)table.Tables[0].Rows[row]["Surname"];
            string username = (string)table.Tables[0].Rows[row]["Username"];
            string password = (string)table.Tables[0].Rows[row]["Password"];
            long phonenumber = (int)table.Tables[0].Rows[row]["PhoneNumber"];
            string email = (string)table.Tables[0].Rows[row]["Email"];
            long bsn = (int)table.Tables[0].Rows[row]["BSN"];
            RoleType role = (RoleType)Enum.Parse(typeof(RoleType), (string)table.Tables[0].Rows[row]["Role"]);
            string job = (string)table.Tables[0].Rows[row]["Job"];
            int department = (int)table.Tables[0].Rows[row]["Department"];
            string note = (string)table.Tables[0].Rows[row]["Note"];
            long contactperson = (int)table.Tables[0].Rows[row]["Contactperson"];

            User u = new User(id,firstname, surname, username, password, phonenumber,contactperson, email, bsn, job,role,department,note);
            return u;

        }


        


    }
}
