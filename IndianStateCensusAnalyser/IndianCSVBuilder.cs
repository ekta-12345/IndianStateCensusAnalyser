using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{

    public interface IndianCensusCSVBuilder
    {
        object LoadCSVFileData(string csvFilePath, string fileHeaders);
    }
}