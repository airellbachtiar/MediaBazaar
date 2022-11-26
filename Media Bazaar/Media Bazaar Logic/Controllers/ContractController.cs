using System;
using System.Collections.Generic;
using System.Data;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.DAL;
using Media_Bazaar_Logic.Enums;
using Media_Bazaar_Logic.Parsers;

namespace Media_Bazaar_Logic.Controllers
{
    public class ContractController
    {



        public ContractController()
        {
        }

        public void CreateNewContract(long bsn, ContractType contracttype, double hourrate, DateTime startdate, DateTime enddate)
        {
            

            int userID = EmployeeDAL.GetUserIDByBSN(bsn);
            ContractDAL.AddNewContract(userID, (contracttype + 1), hourrate, startdate, enddate);

        }

        //public Contract GetContractsByID(int id)
        //{
        //    return ContractParser.DataSetToUser(ContractDAL.GetContractByID(id), 0);
        //}

        public List<Contract> GetContractsByID(int id)
        {
            DataSet d = ContractDAL.GetContractByID(id);
            List<Contract> list = new List<Contract>();

            for (int x = 0; x < d.Tables[0].Rows.Count; x++)
            {
                Contract p = ContractParser.DataSetToUser(d, x);
                list.Add(p);
            }
            return list;
        }

        public void FireEmployee(int id,DateTime date,DateTime latestcontract)
        {


            
            ContractDAL.TerminateContractByID(id,date,latestcontract);

        }

    }
}
