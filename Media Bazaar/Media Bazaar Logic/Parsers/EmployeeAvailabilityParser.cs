using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_Logic.Parsers
{
    public static class EmployeeAvailabilityParser
    {
        public static List<List<string>> GetEmpAvailability(DataSet data)
        {
            List<List<string>> availability = new List<List<string>>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                List<string> empAvail = new List<string>();
                empAvail.Add(data.Tables[0].Rows[row]["empID"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["contractID"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Monday"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Tuesday"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Wednesday"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Thursday"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Friday"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Saturday"].ToString());
                empAvail.Add(data.Tables[0].Rows[row]["Sunday"].ToString());

                availability.Add(empAvail);
            }

            return availability;
        }
    }
}
