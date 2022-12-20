using IndianStatesCensusAnalyserProblem.DTO;

namespace IndianStatesCensusAnalyserProblem
{
    public class CsvAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string path, string csvHeaders)
        {
            try
            {
                switch (country)
                {
                    case (CensusAnalyser.Country.INDIA):
                        {
                            return new IndianStateCensusAdapter().LoadCensusData(path, csvHeaders);
                        }
                    default:
                        {
                            throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY, "No such country present");
                        }
                }
            }
            catch (StateCensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
