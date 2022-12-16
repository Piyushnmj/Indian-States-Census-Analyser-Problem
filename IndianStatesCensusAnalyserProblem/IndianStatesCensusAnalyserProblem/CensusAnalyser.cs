using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class CensusAnalyser : CensusAdapter, IStateCensusCSVOperations
    {
        public string[] LoadCountryCsv(string csvFilePath, string header)
        {
            string[] result = new string[50];

            try
            {
                result = GetCensusData(csvFilePath, header);
                foreach (var data in result.Skip(1))
                {
                    if (!data.Contains(","))
                    {
                        throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, "Invalid Delimiter");
                    }
                }
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
