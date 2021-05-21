using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyserException : Exception //user define exception class
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INCORRECT_FILE_TYPE, INVALID_DELIMITER, INVALID_HEADERS//exception type
        }
        public ExceptionType type;

        public CensusAnalyserException(String message, ExceptionType type) : base(String.Format(message))
        {
            this.type = type;
        }
    }
}

