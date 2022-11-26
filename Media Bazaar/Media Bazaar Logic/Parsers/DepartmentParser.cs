using System.Data;
using Media_Bazaar_Logic.Class;

namespace Media_Bazaar_Logic.Parsers
{
    public static class DepartmentParser
    {


        public static Department DataSetToUser(DataSet table, int row)
        {
            int depid = (int)table.Tables[0].Rows[row]["departmentid"];
            string depname = (string)table.Tables[0].Rows[row]["departmentname"];
            string depdescription = (string)table.Tables[0].Rows[row]["description"];


            Department u = new Department(depid, depname, depdescription);
            return u;

        }

    }
}
