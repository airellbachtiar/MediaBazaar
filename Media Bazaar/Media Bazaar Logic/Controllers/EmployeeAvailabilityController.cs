using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Media_Bazaar_Logic.DAL;
using Media_Bazaar_Logic.Parsers;

namespace Media_Bazaar_Logic.Controllers
{
    public static class EmployeeAvailabilityController
    {
        public static List<List<string>> GetEmpAvailability()
        {
            DataSet data = EmployeeAvailabilityDAL.GetEmpAvailability();
            return EmployeeAvailabilityParser.GetEmpAvailability(data);
        }

        public static void UpdateEmpAvailability(List<string> availability)
        {
            EmployeeAvailabilityDAL.UpdateUserAvailability(availability);
        }
    }
}
