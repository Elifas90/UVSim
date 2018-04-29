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
        private Thread[] threads;
        private int currentThread;

        /// <summary>
        /// Shows if all threads terminated
        /// </summary>
        public bool Terminated
        {
            get
            {
                // Check every existing thread for termination
                foreach (Thread thread in threads)
                {
                    if (!thread.Terminated)
                        return false;
                }
                return true;
            }
        }

        // Default constructor.
        public VirtualMachine(MemoryManager m, int numPrograms, IUVSimController w)
        {
            memory = m;
            window = w;
            currentThread = 0;

            // Creating virtual threads
            threads = new Thread[numPrograms];
            for (int i=0; i<numPrograms; i++)
            {
                Thread thread = new Thread(i);
                threads[i] = thread;
            }
        }

        // A function to execute the instruction from the memory array.
        public void Execute()
        {
            // Continue execution before all threads will be terminated
            while (!Terminated)
            {
                // get thread for execution
                currentThread = (currentThread + 1) % threads.Length;
                Thread thread = threads[currentThread];

                // Execute next instruction in thread
                thread.Execute(memory, window);
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
