using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class CSVFactory
    {
        public IndianCensusCSVBuilder getIndianCensusAnalyser()
        {
            return new CensusAnalyser();
        }
    }
}
