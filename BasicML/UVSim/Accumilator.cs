using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVSim
{
    //-----------------------------------------------------------------------------------------------------------------------
    //  File Designed by: Josh Cooley

    // Implementation file for the "Accumilator" class.

    public class Accumilator
    {
        private static Accumilator _instance;

        public int Value { get; set; }

        public static Accumilator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Accumilator();
                }
                return _instance;
            }
        }

        private Accumilator() { }
    }
}
