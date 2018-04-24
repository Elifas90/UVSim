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
    /// Base class for BasicML functions
    /// </summary>
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
        public abstract void Branch(ref int pc);
        public abstract void BranchNeg(ref int pc);
        public abstract void BranchZero(ref int pc);
    }
}
