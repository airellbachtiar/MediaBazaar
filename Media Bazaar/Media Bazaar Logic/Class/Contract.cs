using System;
using Media_Bazaar_Logic.Enums;

namespace Media_Bazaar_Logic.Class
{
    public class Contract
    {
        private int id;
        ContractType contracttype;
        private double hourRate;
        private DateTime startDate;
        private DateTime endDate;

        public Contract(int id,ContractType contracttype, double hourrate,DateTime startdate,DateTime enddate)
        {
            this.id = id;
            this.contracttype = contracttype;
            this.hourRate = hourrate;
            this.startDate = startdate;
            this.endDate = enddate;
        }

        public int ID
        {
            get { return this.id; }
        }
        public ContractType Contracttype
        {
            get { return this.contracttype; }
        }
        public double HourRate
        {
            get { return this.hourRate; }
        }
        public DateTime StartDate
        {
            get { return this.startDate; }
        }
        public DateTime EndDate
        {
            get { return this.endDate; }
        }

    }
}
