using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVSim
{
    //-----------------------------------------------------------------------------------------------------------------------
    //  File Designed by: Ali Alabdlmohsen

    // Implementation file for the "AssemblerException" class.
    public class AssemblerException : ApplicationException
    {
        public int InstrctionNumber { get; private set; }

        public AssemblerException(string message, int lineNum) : base(message)
        {
            InstrctionNumber = lineNum;
        }
    }
}
