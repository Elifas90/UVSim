using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-----------------------------------------------------------------------------------------------------------------------
//  File Designed by: Ali Alabdlmohsen

// Implementation file for the "ALU" class.

namespace UVSim
{
    public class ALU
    {
        // A function to add two integers using logic gates.
        public int Add(int a, int b)
        {
            // loop until no carry  
            while (b != 0)
            {
                int carry = a & b;
                a = a ^ b;
                b = carry << 1;
            }

            return a;
        }

        // A function to subtract two integers using logic gates.
        public int Subtract(int a, int b)
        {
            // loop until no carry  
            while (b != 0)
            {
                int borrow = (~a) & b;
                a = a ^ b;
                b = borrow << 1;
            }

            return a;
        }

        // A function to divide two numbers using logic gates.
        public int Divide(int a, int b)
        {
            // check for divide by zero
            if (b == 0)
                throw new DivideByZeroException();

            int count = 0;

            while (true)
            {
                if (a < b) return count;

                else
                {
                    count++;
                    a = Subtract(a, b);
                }

            }
        }

        // A function to multiply two numbers using logic gates.
        public int Multiply(int a, int b)
        {
            int sum = 0;

            if (a == 0 || b == 0) return sum;

            else
            {
                for (int i = 0; i < b; i++)
                {
                    sum = Add(sum, a);
                }

                return sum;
            }
        }

        // A function to get the reminder of two numbers using logic gates.
        public int Reminder(int a, int b)
        {
            int reminder = 0;

            if (a == b) return reminder;

            else
            {
                int factor = Divide(a, b);
                int total = Multiply(factor, b);
                reminder = a - total;

                return reminder;
            }
        }

        // A function to get the exponential of two numbers using logic gates.
        public int Exponential(int a, int b)
        {
            if (a == 0) return 0;

            else if (b == 0 || a == 1) return 1;

            else
            {
                int result = a;
                for (int i = 1; i < b; i++)
                {
                    result = Multiply(result, a);
                }

                return result;
            }
        }
    }
}
