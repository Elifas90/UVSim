using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVSim
{
    //-----------------------------------------------------------------------------------------------------------------------
    //  File Designed by: Josh Cooley

    // Implementation file for the "MemoryManager" class.
    public class MemoryManager
    {
        public const int MEMORY_SIZE = 1000;

        private int[] memory;
        private int instructionCount;

        public int this[int index]
        {
            get { return GetValueFromMemory(index); }
            set { InsertValueInMemory(index, value); }
        }

        public MemoryManager()
        {
            memory = new int[MEMORY_SIZE];
        }

        /// <summary>
        /// Add new instruction to memory
        /// </summary>
        /// <param name="instruction">Instruction</param>
        public void AddInstruction(string instruction)
        {
            // if input is empty assume that it '0000' there
            if (string.IsNullOrEmpty(instruction))
            {
                instruction = "0000";
            }

            // Check if there are free space in memory
            int num = 0;
            if (instructionCount >= MEMORY_SIZE)
                return;

            // Parse instruction into number
            if (!int.TryParse(instruction, out num))
            {
                instructionCount = 0;
                throw new AssemblerException("Can't parse command!", instructionCount);
            }

            // Save into memory
            memory[instructionCount] = num;
            instructionCount++;
        }

        public int GetValueFromMemory(int index)
        {
            return memory[index];
        }

        public void InsertValueInMemory(int index, int value)
        {
            memory[index] = value;
        }
    }
}
