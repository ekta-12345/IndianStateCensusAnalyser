using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyser : IndianCensusCSVBuilder
    { // UC1:- Ability for the analyser to load the Indian States Census Information from a csv file.
              
      
        public delegate object CSVFileData(string csvFilePath, string fileHeaders);
        List<string> indCensusData = new List<string>();

       
        public object LoadCSVFileData(string csvFilePath, string fileHeaders)
        {
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Incorrect Type", CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE);
            }
            indCensusData = File.ReadAllLines(csvFilePath).ToList();
            if (indCensusData[0] != fileHeaders)
            {
                throw new CensusAnalyserException("Invalid Headers", CensusAnalyserException.ExceptionType.INVALID_HEADERS);
            }
            foreach (string data in indCensusData)
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("Invalid Delimiters In File", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                }
            }
            return indCensusData.Skip(1).ToList();
        }
       

    }
}
