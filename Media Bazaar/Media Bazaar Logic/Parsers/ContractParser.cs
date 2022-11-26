using System;
using System.Data;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Enums;

namespace Media_Bazaar_Logic.Parsers
{
    public static class ContractParser
    {

        public static Contract DataSetToUser(DataSet table, int row)
        {
            
            int id = (int)table.Tables[0].Rows[row]["EmployeeID"];
            ContractType contracttype  = (ContractType)Enum.Parse(typeof(ContractType), (string)table.Tables[0].Rows[row]["ContractID"]);
            double hourrate = (double)table.Tables[0].Rows[row]["HourRate"];
            DateTime startdate = (DateTime)table.Tables[0].Rows[row]["StartDate"];
            DateTime enddate = (DateTime)table.Tables[0].Rows[row]["EndDate"];


            Contract u = new Contract(id,contracttype,hourrate,startdate,enddate);
            return u;

        }





    }
}
