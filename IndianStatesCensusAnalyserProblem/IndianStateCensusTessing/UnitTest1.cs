using IndianStatesCensusAnalyserProblem;
using IndianStatesCensusAnalyserProblem.DTO;

namespace IndianStateCensusTessing
{
    [TestClass]
    public class UnitTest1
    {
        CsvAdapterFactory objCsvAdapter = default;
        Dictionary<string, CensusDTO> allStateRecord;

        string censusFilePath = @"F:\Bridgelabz Codin\Indian-States-Census-Analyser-Problem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\Utility\IndianStateCensusInfo.csv";
        string invalidCsvFilePath = @"F:\Bridgelabz Codin\Indian-States-Census-Analyser-Problem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\Utility\IndianStateCensusInfo2.csv";
        string invalidFileTypePath = @"F:\Bridgelabz Codin\Indian-States-Census-Analyser-Problem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\Utility\InvalidCensusFileType.txt";
        string invalidDelimiterFilePath = @"F:\Bridgelabz Codin\Indian-States-Census-Analyser-Problem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\Utility\IndianStateCensusInfo_InvalidDelimiter.csv";
        string invalidHeaderFilePath = @"F:\Bridgelabz Codin\Indian-States-Census-Analyser-Problem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\Utility\IndianStateCensusInfo_InvalidHeader.csv";

        [TestInitialize]
        public void SetUp()
        {
            objCsvAdapter = new CsvAdapterFactory();
            allStateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TC1.1 - Count Number of Records
        /// </summary>
        [TestMethod]
        public void GivenStateCensusCSV_ReturnCountOfFields()
        {
            int expected = 28;
            allStateRecord = objCsvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, censusFilePath,"State,Population,Area,Density");
            int actual = allStateRecord.Count;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC1.2 - Check if File Exists or not
        /// </summary>
        [TestMethod]
        public void TestMethodToCheckInvalidFiles()
        {
            try
            {
                objCsvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, invalidCsvFilePath, "State,Population,Area,Density");
            }
            catch (StateCensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "File not found");
            }
        }

        /// <summary>
        /// TC1.3 - Check for correct Extension
        /// </summary>
        [TestMethod]
        public void TestMethodToCheckInvalidFileExtension()
        {
            try
            {
                objCsvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, invalidFileTypePath, "State,Population,Area,Density");
            }
            catch (StateCensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Invalid file extension");
            }
        }

        /// <summary>
        /// TC1.4 - Check for proper Delimiter
        /// </summary>
        [TestMethod]
        public void TestMethodToCheckInvalidDelimiter()
        {
            try
            {
                objCsvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, invalidDelimiterFilePath, "State,Population,Area,Density");
            }
            catch (StateCensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Invalid Delimiter");
            }
        }

        /// <summary>
        /// TC1.5 - Check for incorrect header
        /// </summary>
        [TestMethod]
        public void TestMethodToCheckInvalidHeader()
        {
            try
            {
                objCsvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, invalidHeaderFilePath, "State,Population,Area,Density");
            }
            catch (StateCensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Invalid file headers");
            }
        }
    }
}