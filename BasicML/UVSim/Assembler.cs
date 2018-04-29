using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVSim
{
    public class Assembler
    {
        MemoryManager memory;
        private IUVSimController window;

        public Assembler(IUVSimController window, MemoryManager mm)
        {
            this.window = window;
            memory = mm;
        }

        public void PrintIntroduction()
        {
            window.Console.ClearConsole();
            window.Console.WriteLine("Welcome to UVUsim");
            window.Console.WriteLine("---------------------------------------------");
        }

        public void ReadInstructions(string[] instructions)
        {
            foreach (string input in instructions)
            {
                try
                {
                    memory.AddInstruction(input);
                }
                catch (AssemblerException ex)
                {
                    window.Error(ex.InstrctionNumber, ex.Message);
                }
            }

            window.Console.WriteLine("---------------------------------------------");
        }

        /// <summary>
        /// Returns memory
        /// </summary>
        /// <returns>Memory manager</returns>
        public MemoryManager GetMemory()
        {
            return memory;
        }

        /// <summary>
        /// Returns number of programs loaded into memory
        /// </summary>
        /// <returns>Number of Programs</returns>
        public int GetProgramCount()
        {
            int lineNumber = MemoryManager.MEMORY_SIZE-1;
            while ((lineNumber > 0) && (memory[lineNumber] == 0))
                lineNumber--;

            return (int)Math.Ceiling((double)lineNumber / Thread.THREAD_OFFSET);
        }
    }
}
