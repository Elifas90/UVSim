using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-----------------------------------------------------------------------------------------------------------------------
//  File Designed by: Nikita Pestin

// Implementation file for the "BasicML" class.

namespace UVSim
{
    /// <summary>
    /// Base class for BasicML Math functions
    /// </summary>
    public abstract class BasicMLMath
    {
        protected IUVSimController window;
        protected MemoryManager memory;
        protected ALU alu;

        public BasicMLMath(IUVSimController w, MemoryManager m)
        {
            window = w;
            memory = m;
            alu = new ALU();
        }

        /// <summary>
        /// Get Double Word from memory
        /// </summary>
        protected int ComposeDWORD(ref int pc)
        {
            // get hiword
            int hiword = memory[pc];

            // Increment the program counter to get to the 2-digit loword.
            pc++;
            int loword = memory[pc] / 100;

            // Combine loword and hiword into 6-digit number
            int dword = hiword * 100 + loword;

            return dword;
        }

        /// <summary>
        /// Save dpuble word value 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="value"></param>
        protected void SaveDWORD(int location, int value)
        {
            // Decompose value into hiword and loword
            int hiword = value / 100;
            int loword = value % 100;

            // Write them into respective locations
            memory[location] = hiword;
            memory[location + 1] = loword;
        }

        /// <summary>
        /// Get Word from memory
        /// </summary>
        /// <param name="pc"></param>
        /// <returns></returns>
        public int ComposeWORD(ref int pc)
        {
            // Increment th program counter to get operand
            pc++;

            return memory[pc];
        }

        public abstract void Add(ref int pc);
        public abstract void Subtract(ref int pc);
        public abstract void Divide(ref int pc);
        public abstract void Multiply(ref int pc);
        public abstract void Reminder(ref int pc);
        public abstract void Exponential(ref int pc);
    }
}
