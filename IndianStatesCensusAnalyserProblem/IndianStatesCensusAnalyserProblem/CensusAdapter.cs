using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class CensusAdapter
    {
        public string[] GetCensusData(string csvStateFilePath, string dataHeaders)
        {
            string[] statusData;
            
            if (!File.Exists(csvStateFilePath))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, "File not found!");
            }
            if (Path.GetExtension(csvStateFilePath) != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, "Invalid Extension");
            }
            statusData = File.ReadAllLines(csvStateFilePath);
            if (statusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, "Incorrect Header");
            }
            return statusData;
        }
    }
}
