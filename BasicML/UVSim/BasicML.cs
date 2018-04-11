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
    public abstract class BasicML
    {
        protected IUVSimController window;
        protected MemoryManager memory;
        protected ALU alu;

        public BasicML(IUVSimController w, MemoryManager m)
        {
            window = w;
            memory = m;
            alu = new ALU();
        }

        public abstract void Read(ref int pc);
        public abstract void Write(ref int pc);
        public abstract void Load(ref int pc);
        public abstract void Store(ref int pc);
        public abstract void Add(ref int pc);
        public abstract void Subtract(ref int pc);
        public abstract void Divide(ref int pc);
        public abstract void Multiply(ref int pc);
        public abstract void Reminder(ref int pc);
        public abstract void Exponential(ref int pc);
        public abstract void Branch(ref int pc);
        public abstract void BranchNeg(ref int pc);
        public abstract void BranchZero(ref int pc);
    }
}
