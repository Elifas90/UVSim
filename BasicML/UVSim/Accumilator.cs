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
        public const int MIN_NUMBER = -999999;
        public const int MAX_NUMBER = 999999;

        private static Accumilator _instance;

        private int _value;

        public int Value
        {
            get { return _value; }
            set
            {
                if ((value < MIN_NUMBER) || (value > MAX_NUMBER))
                    throw new ApplicationException("Overflow error: The value is beyond range.");
                _value = value;
            }
        }

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
