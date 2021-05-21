using NUnit.Framework;
using IndianStateCensusAnalyser;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;
using System;

namespace IndianStateCensusTest
{
    public class Tests
    {
        //UC1
        static string CSVFilePath = @"D:\C#\IndianStateCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        static string InvalidFilePath = @"D:\C#\IndianStateCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        static string InvalidCSVTypeFilePath = @"D:\C#\IndianStateCensusAnalyser\CSVFiles\CensorAnalyser.cs";
        static string InvalidDeliminatorFilePath = @"D:\C#\IndianStateCensusAnalyser\CSVFiles\IncorrectDeliminatorCensusFile.csv";
        static string InvalidHeaderFilePath = @"D:\C#\IndianStateCensusAnalyser\CSVFiles\DelimiterIndiaStateCode.csv";
        //UC2
        static string CSVStateCodeFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\IndiaStateCode.csv";
        static string InvalidDeliminatorStateCodeFilePath = @"D:\Practice\C#\Indian States Census Analyser Problem\Indian States Census Analyser Problem\CSVFiles\InvalidDeliminatorIndiaStateCode.csv";

        static string StateCensusFileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm"; //file header
        static string StateCodeFileHeaders = "SrNo,State Name,TIN,StateCode";//state code file header

        CensusAnalyser censusAnalyser;
        CSVFileData csvFileData;
        CSVFactory csvFactory;
        List<string> totalNumberOfRecords;

        

        [SetUp]
        public void Setup()
        {
            csvFactory = new CSVFactory();
            totalNumberOfRecords = new List<string>();
        }

        // TC1.1- From the given States Census CSV file, Check and ensure the Number of Record matches.
                            
        [Test]
        public void FromGivenIndianCensusCSVFile_IfCorrect_ShouldReturnNoOfRecords()
        {
            try
            {
                CensusAnalyser censusAnalyser = (CensusAnalyser)csvFactory.getIndianCensusAnalyser();
                csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
                totalNumberOfRecords = (List<string>)csvFileData(CSVFilePath, StateCensusFileHeaders);
                Assert.AreEqual(29, totalNumberOfRecords.Count);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        //TC1.2:- From the given State Census CSV File check if incorrect Returns a custom Exception.
                   
         
        [Test]
        public void FromGivenIndianCensusCSVFile_WhenNotFound_ShouldThrowAnException()
        {
            try
            {
                CensusAnalyser censusAnalyser = (CensusAnalyser)csvFactory.getIndianCensusAnalyser();
                csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
                var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidFilePath, StateCensusFileHeaders));
            }
            catch (CensusAnalyserException ex)
            {

                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.type);
            }
        }

        // TC1.3:- Check from the given State Census CSV File if it is correct but the type is incorrect Returns a custom Exception.
                 
         
        [Test]
        public void FromGivenIndianCensusCSVFile_IfIncorrectFileType_ShouldThrowAnException()
        {
            try
            {
                CensusAnalyser censusAnalyser = (CensusAnalyser)csvFactory.getIndianCensusAnalyser();
                csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
                var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidCSVTypeFilePath, StateCensusFileHeaders));
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, ex.type);
            }
        }

        // TC1.4:- From the given State Census CSV File if it is correct but delimiter is incorrect should return a custom Exception.
                   
         
        [Test]
        public void FromGivenIndianCensusCSVFile_IfIncorrectDeliminatorPresentInFile_ShouldThrowException()
        {
            try
            {
                CensusAnalyser censusAnalyser = (CensusAnalyser)csvFactory.getIndianCensusAnalyser();
                csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
                var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidDeliminatorFilePath, StateCensusFileHeaders));
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, ex.type);
            }
        }

        // TC1.5:- From the given State Census CSV File if correct but csv header is incorrect should return a custom Exception.
                   
        
        [Test]
        public void FromGivenIndianCensusCSVFile_WhenIncorrectHeadersPresentInFile_ShouldThrowException()
        {
            try
            {
                CensusAnalyser censusAnalyser = (CensusAnalyser)csvFactory.getIndianCensusAnalyser();
                csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
                var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidHeaderFilePath, StateCensusFileHeaders));
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, ex.type);
            }
        }
        // 2.1:- From the given States Census CSV file, Check and ensure if the number of record matches.
                
        [Test]
        public void FromGivenStateCensusCSVFile_IfCorrect_ShouldReturnNoOfRecords()
        {

            CensusAnalyser censusAnalyser = (CensusAnalyser)csvFactory.getIndianCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            totalNumberOfRecords = (List<string>)csvFileData(CSVStateCodeFilePath, StateCodeFileHeaders);
            Assert.AreEqual(37, totalNumberOfRecords.Count);
        }

        // TC2.2:-From the given State Census CSV File, if incorrect Returns a custom Exception.
                 
        
        [Test]
        public void FromGivenStateCodesCSVFile_IfFileNotFound_ShouldThrowCustomException()
        {
            try
            {

                CensusAnalyser censusAnalyser = (CensusAnalyser)csvFactory.getIndianCensusAnalyser();
                csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
                var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidFilePath, StateCodeFileHeaders));

            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.type);
            }
        }
        // TC2.3:-From given State Census CSV File, if correct but type is incorrect should return a custom Exception.
               
       
        [Test]
        public void FromGivenStateCodesCSVFile_IfIncorrectFileType_ShouldThrowCustomException()
        {
            try
            {

                CensusAnalyser censusAnalyser = (CensusAnalyser)csvFactory.getIndianCensusAnalyser();
                csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
                var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidCSVTypeFilePath, StateCodeFileHeaders));
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, ex.type);
            }

        }
        // TC2.4:- From the given State Census CSV File, if correct but delimiter is incorrect should return a custom Exception.
                 
        [Test]
        public void FromGivenStateCodesCSVFile_IfIncorrectDeliminatorPresentInFile_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = (CensusAnalyser)csvFactory.getIndianCensusAnalyser();
                csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
                var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidDeliminatorStateCodeFilePath, StateCodeFileHeaders));
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, ex.type);
            }
        }
        // TC2.5:- From the given the State Census CSV File ,if correct but csv header incorrect should return a custom Exception.
                  
         
        [Test]
        public void FromGivenStateCodesCSVFile_IfIncorrectHeadersPresentInFile_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = (CensusAnalyser)csvFactory.getIndianCensusAnalyser();
                csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
                var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidHeaderFilePath, StateCodeFileHeaders));
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, ex.type);
            }

        }
    }
}
    
