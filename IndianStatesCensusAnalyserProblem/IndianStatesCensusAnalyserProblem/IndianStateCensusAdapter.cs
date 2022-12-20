using IndianStatesCensusAnalyserProblem.DataDAO;
using IndianStatesCensusAnalyserProblem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class IndianStateCensusAdapter : GetCensusDataAdapter
    {
        string[] IndianStateCensusInfo;
        Dictionary<string, CensusDTO> dataDict;

        public Dictionary<string, CensusDTO> LoadCensusData(string filePath, string csvHeaders)
        {
            try
            {
                dataDict = new Dictionary<string, CensusDTO>();
                IndianStateCensusInfo = GetData(filePath, csvHeaders);
                foreach (string data in IndianStateCensusInfo.Skip(1))
                {
                    if (!data.Contains(","))
                    {
                        throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.INVALID_DELIMITER, "Invalid Delimiter");
                    }

                    string[] lines = data.Split(",");

                    if (filePath.Contains("IndianStateCensusInfo.csv"))
                    {
                        dataDict.Add(lines[1], new CensusDTO(new CensusDataDAO(lines[0], lines[1], lines[2], lines[3])));
                    }
                    if (filePath.Contains("StateCodes.csv"))
                    {
                        dataDict.Add(lines[1], new CensusDTO(new StateCodesDAO(lines[0], lines[1], lines[2], lines[3])));
                    }
                }
                return dataDict;
            }
            catch (StateCensusAnalyserException ex)
            {
                throw ex;
            }

        }
    }
}
