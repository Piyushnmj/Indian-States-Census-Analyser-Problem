using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class CsvAdapterFactory
    {
        public string[] LoadCsvData(CountryCheck.Country country, string csvFilePath, string headers)
        {
            try
            {
                switch (country)
                {
                    case (CountryCheck.Country.INDIA):
                        {
                            return new CensusAnalyser().LoadCountryCsv(csvFilePath, headers);
                        }
                    default:
                        {
                            throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY, "NO SUCH COUNTRY");
                        }
                }
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
