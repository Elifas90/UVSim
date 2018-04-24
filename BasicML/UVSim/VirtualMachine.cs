using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-----------------------------------------------------------------------------------------------------------------------
//  File Designed by: Josh Cooley

// Implementation file for the "vm" class.

namespace UVSim
{
    public class VirtualMachine
    {
        private int pc;
        private MemoryManager memory;
        private IUVSimController window;

        // Defult constructor.
        public VirtualMachine(MemoryManager m, IUVSimController w)
        {
            memory = m;
            window = w;
        }

        // A function to execute the instruction from the memory array.
        public void Execute()
        {
            int opCode;

            // Create executioners
            BasicML directExecution = new BasicMLDirect(window, memory);
            BasicML indirectExecution = new BasicMLIndirect(window, memory);
            BasicMLMath directMath = new BasicMLMathDirect(window, memory);
            BasicMLMath indirectMath = new BasicMLMathIndirect(window, memory);

            // A loop to go over the memory until HALT is encountered.
            while (true)
            {
                // Get the opCode
                opCode = memory[pc] / 100;

                // Switch statment to execute the targeted instruction based on the opCode.
                switch (opCode)
                {
                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Josh Cooley

                    // READ
                    case 10:

                        directExecution.Read(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Josh Cooley

                    // WRITE
                    case 11:

                        directExecution.Write(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Josh Cooley

                    // READ - INDIRECT
                    case 12:

                        indirectExecution.Read(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Josh Cooley

                    // WRITE - INDIRECT
                    case 13:

                        indirectExecution.Write(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Josh Cooley

                    // LOAD
                    case 20:

                        directExecution.Load(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Nikita Pestin

                    // STORE
                    case 21:

                        directExecution.Store(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Nikita Pestin

                    // LOAD - INDIRECT
                    case 22:

                        indirectExecution.Load(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Nikita Pestin

                    // STORE - INDIRECT
                    case 23:

                        indirectExecution.Load(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Nikita Pestin

                    // ADD
                    case 30:

                        directMath.Add(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Nikita Pestin

                    // SUBTRACT
                    case 31:

                        directMath.Subtract(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Caleb Hansen

                    // DIVIDE
                    case 32:

                        directMath.Divide(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Caleb Hansen

                    // MULTIPLY
                    case 33:

                        directMath.Multiply(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Nikita Pestin

                    // ADD - INDIRECT
                    case 34:

                        indirectMath.Add(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Nikita Pestin

                    // SUBTRACT - INDIRECT
                    case 35:

                        indirectMath.Subtract(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Nikita Pestin

                    // DIVIDE - INDIRECT
                    case 36:

                        indirectMath.Divide(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Nikita Pestin

                    // MULTIPLY - INDIRECT
                    case 37:

                        indirectMath.Multiply(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Caleb Hansen

                    // BRANCH
                    case 40:

                        directExecution.Branch(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Ali Alabdlmohsen

                    // BRANCHNEG
                    case 41:

                        directExecution.BranchNeg(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Ali Alabdlmohsen

                    // BRANCHZERO
                    case 42:

                        directExecution.BranchZero(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Ali Alabdlmohsen

                    // HALT
                    case 43:

                        // End the execution.
                        window.Console.WriteLine("---------------------------------------------");
                        return;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Caleb Hansen

                    // BRANCH - Josh Cooley
                    case 44:

                        indirectExecution.Branch(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Ali Alabdlmohsen

                    // BRANCHNEG - INDIRECT
                    case 45:

                        indirectExecution.BranchNeg(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Ali Alabdlmohsen

                    // BRANCHZERO - INDIRECT
                    case 46:

                        indirectExecution.BranchZero(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Ali Alabdlmohsen

                    // REMINDER
                    case 50:

                        directMath.Reminder(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Ali Alabdlmohsen

                    // EXPONENTIATION
                    case 51:

                        directMath.Exponential(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Ali Alabdlmohsen

                    // REMINDER - INDIRECT
                    case 52:

                        indirectMath.Reminder(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Ali Alabdlmohsen

                    // EXPONENTIATION - INDIRECT
                    case 53:

                        indirectMath.Exponential(ref pc);

                        break;

                    // Defult.
                    default:

                        // Increment the program counter.
                        pc++;

                        break;
                }
            }
        }

        // Print the accumelator and memory dump.
        public void PrintFooter()
        {
            window.Console.WriteLine($"Accumilator: {Accumilator.Instance.Value}");
            window.Console.WriteLine("---------------------------------------------");
            MemoryDump();

            window.Console.WriteLine("");
            window.Console.WriteLine("");
            window.Console.WriteLine("---------------------------------------------");
        }

        // A function that prints the contents of the memory array.
        public void MemoryDump()
        {
            int count = 0;

            window.Console.WriteLine("Memory Dump:");
            window.Console.WriteLine("------------");

            // Print the first row.
            window.Console.Write(" #     ");
            for (int i = 0; i < MemoryManager.MEMORY_SIZE / 100; i++)
            {
                window.Console.Write(i.ToString("D4") + "\t");
            }
            window.Console.WriteLine("");

            // Print the second row.
            window.Console.Write("\t");
            for (int i = 0; i < MemoryManager.MEMORY_SIZE / 100; i++)
            {
                window.Console.Write("------\t");
            }
            window.Console.WriteLine("");

            // Print the memory dumb.
            window.Console.Write("000 :  ");
            for (int i = 0; i < MemoryManager.MEMORY_SIZE; i++)
            {
                window.Console.Write(memory[i].ToString("D4") + "\t");
                count++;

                // Formatting
                if (count == 10 && i < MemoryManager.MEMORY_SIZE - 1)
                {
                    count = 0;
                    window.Console.WriteLine("");
                    window.Console.Write((i + 1).ToString("D3") + " :  ");
                }
            }
        }
    }
}
