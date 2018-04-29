using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-----------------------------------------------------------------------------------------------------------------------
//  File Designed by: Josh Cooley

// Implementation file for the "Thread" class.

namespace UVSim
{
    /// <summary>
    /// Class that emulates thread in UVSim
    /// </summary>
    public class Thread
    {
        public const int MAX_THREAD = 4;
        public const int THREAD_OFFSET = 250;

        private int threadNumber;
        private bool terminated;

        /// <summary>
        /// Number of virtual thread
        /// </summary>
        public int ThreadNumber
        {
            get { return threadNumber; }
        }

        /// <summary>
        /// Shows if thread terminated
        /// </summary>
        public bool Terminated
        {
            get { return terminated; }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="threadNumber">Number of virtual thread</param>
        public Thread(int threadNumber)
        {
            this.threadNumber = threadNumber;
        }

        /// <summary>
        /// Execute new instruction in the thread
        /// </summary>
        /// <param name="memory">System memory</param>
        /// <param name="window">UVSim Controller</param>
        public void Execute(MemoryManager memory, IUVSimController window)
        {
            // Check if thread was terminated
            if (Terminated)
                return;

            // Create executioners
            BasicML directExecution = new BasicMLDirect(window, memory);
            BasicML indirectExecution = new BasicMLIndirect(window, memory);
            BasicMLMath directMath = new BasicMLMathDirect(window, memory);
            BasicMLMath indirectMath = new BasicMLMathIndirect(window, memory);

            // Retrieve pc value from memory
            int pc = memory[THREAD_OFFSET * ThreadNumber + (THREAD_OFFSET - 1)];
            pc = THREAD_OFFSET * ThreadNumber + pc;

            //Retrieve register from memory
            int memoryLocation = THREAD_OFFSET * ThreadNumber + (THREAD_OFFSET - 3);
            Accumilator.Instance.Value = directExecution.ComposeDWORD(ref memoryLocation);

            try
            {
                int opCode;

                // Get the opCode
                opCode = memory[pc] / 100;

                // Switch statment to execute the targeted instruction based on the opCode.
                switch (opCode)
                {
                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Josh Cooley

                    // READ
                    case 10:
                        window.Console.Write($"[Thread #{ThreadNumber}] ");
                        directExecution.Read(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Josh Cooley

                    // WRITE
                    case 11:
                        window.Console.Write($"[Thread #{ThreadNumber}] ");
                        directExecution.Write(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Josh Cooley

                    // READ - INDIRECT
                    case 12:
                        window.Console.Write($"[Thread #{ThreadNumber}] ");
                        indirectExecution.Read(ref pc);

                        break;

                    //-----------------------------------------------------------------------------------------------------------------------
                    // Coded by: Josh Cooley

                    // WRITE - INDIRECT
                    case 13:
                        window.Console.Write($"[Thread #{ThreadNumber}] ");
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
                        terminated = true;
                        break;

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
            catch (Exception ex)
            {
                window.Console.Write($"[Thread #{ThreadNumber}] ");
                window.Error(ex.Message);
                terminated = true;
            }

            // Check termination
            if ((pc % THREAD_OFFSET) >= (THREAD_OFFSET-3))
            {
                terminated = true;
            }

            // Save program counter and accumulator to memory
            pc %= THREAD_OFFSET;
            memory[THREAD_OFFSET * ThreadNumber + (THREAD_OFFSET - 1)] = pc;
            directExecution.SaveDWORD(THREAD_OFFSET * ThreadNumber + (THREAD_OFFSET - 3), Accumilator.Instance.Value);
        }
    }
}
