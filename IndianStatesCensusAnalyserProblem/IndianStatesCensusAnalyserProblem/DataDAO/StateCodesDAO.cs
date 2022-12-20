using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem.DataDAO
{
    public class StateCodesDAO
    {
        public int serialNumber;
        public int tin;
        public string stateName;
        public string stateCode;

        public StateCodesDAO(string serialNumber, string tin, string stateName, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.tin = Convert.ToInt32(tin);
            this.stateName = stateName;
            this.stateCode = stateCode;
        }
    }
}
