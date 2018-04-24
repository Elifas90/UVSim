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

        public abstract void Add(ref int pc);
        public abstract void Subtract(ref int pc);
        public abstract void Divide(ref int pc);
        public abstract void Multiply(ref int pc);
        public abstract void Reminder(ref int pc);
        public abstract void Exponential(ref int pc);
    }
}
