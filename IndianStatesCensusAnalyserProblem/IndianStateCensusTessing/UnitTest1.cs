using IndianStatesCensusAnalyserProblem;

namespace IndianStateCensusTessing
{
    [TestClass]
    public class UnitTest1
    {
        IStateCensusCSVOperations censusAnalyser;
        CsvAdapterFactory censusAdapter;

        string censusFilePath = @"F:\Bridgelabz Codin\Indian-States-Census-Analyser-Problem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\IndianStateCensusInfo.csv";
        string invalidCsvFilePath = @"F:\Bridgelabz Codin\Indian-States-Census-Analyser-Problem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\InvalidCensusFile.csv";
        string invalidFileTypePath = @"F:\Bridgelabz Codin\Indian-States-Census-Analyser-Problem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\InvalidCensusFileType.txt";
        string invalidDelimiterFilePath = @"F:\Bridgelabz Codin\Indian-States-Census-Analyser-Problem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\IndianStateCensusInfo_InvalidDelimiter.csv";
        string invalidHeaderFilePath = @"F:\Bridgelabz Codin\Indian-States-Census-Analyser-Problem\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\IndianStateCensusInfo_InvalidHeader.csv";

        [TestInitialize]
        public void SetUp()
        {
            censusAdapter = new CsvAdapterFactory();
        }

        /// <summary>
        /// TC1.1 - Count Number of Records
        /// </summary>
        [TestMethod]
        public void GivenStateCensusCSV_ReturnCountOfFields()
        {
            int expected = 29;
            string[] result = censusAdapter.LoadCsvData(CountryCheck.Country.INDIA, censusFilePath, "State,Population,Increase,Area,Density");
            int actual = result.Length;
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
                censusAdapter.LoadCsvData(CountryCheck.Country.INDIA, invalidCsvFilePath, "State,Population,Increase,Area,Density");
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "File Not Found!");
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
                censusAdapter.LoadCsvData(CountryCheck.Country.INDIA, invalidFileTypePath, "State,Population,Increase,Area,Density");
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Invalid Extension");
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
                censusAdapter.LoadCsvData(CountryCheck.Country.INDIA, invalidDelimiterFilePath, "State,Population,Increase,Area,Density");
            }
            catch (CensusAnalyserException ex)
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
                censusAdapter.LoadCsvData(CountryCheck.Country.INDIA, invalidHeaderFilePath, "State,Population,Increase,Area,Density");
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Invalid Header");
            }
        }
    }
}