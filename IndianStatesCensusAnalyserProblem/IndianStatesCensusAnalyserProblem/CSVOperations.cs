using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public interface IStateCensusCSVOperations
    {
        string[] LoadCountryCsv(string csvFilePath, string header);
    }
}
