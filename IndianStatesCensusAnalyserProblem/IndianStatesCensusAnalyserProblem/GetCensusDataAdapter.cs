using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class GetCensusDataAdapter
    {
        public string[] GetData(string filePath, string csvHeaders)
        {
            try
            {
                if (!Path.GetExtension(filePath).Equals(".csv"))
                {
                    throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, "Invalid file extension");
                }
                string[] data;
                if (!File.Exists(filePath))
                {
                    throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.FILE_NOT_FOUND, "File not found");
                }
                data = File.ReadAllLines(filePath);
                if (!data[0].Equals(csvHeaders))
                {
                    throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.INVALID_HEADER, "Invalid file headers");
                }
                return data;
            }
            catch (StateCensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
