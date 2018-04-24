using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-----------------------------------------------------------------------------------------------------------------------
//  File Designed by: Nikita Pestin

// Implementation file for the "BasicMLDirect" class.

namespace UVSim
{
    /// <summary>
    /// Direct implementations of BasicML Module
    /// </summary>
    public class BasicMLDirect : BasicML
    {
        public BasicMLDirect(IUVSimController w, MemoryManager m) : base(w, m)
        {
        }

        public override void Branch(ref int pc)
        {
            int operand = memory[pc] % 100;

            // Branch to a location in memory based on the operand.
            pc = operand;
        }

        public override void BranchNeg(ref int pc)
        {
            int operand = memory[pc] % 100;

            // If the integer in the Accumilator.Instance.Value is negative, branch to a location in memory based on the operand.
            if (Accumilator.Instance.Value < 0) pc = operand;

            // If not, increment the program counter.
            else pc++;
        }

        public override void BranchZero(ref int pc)
        {
            int operand = memory[pc] % 100;

            // If the integer in the Accumilator.Instance.Value is zero, branch to a location in memory based on the operand.
            if (Accumilator.Instance.Value == 0) pc = operand;

            // If not, increment the program counter.
            else pc++;
        }

        public override void Load(ref int pc)
        {
            int operand = memory[pc] % 100;

            // Read an integer from a memory location based on the operand, and load it in the Accumilator.Instance.Value.
            Accumilator.Instance.Value = memory[operand];

            // Increment the program counter.
            pc++;
        }

        public override void Read(ref int pc)
        {
            int operand = memory[pc] % 100;

            // Read an integer from the keyboard, and store it in a memory location based on the operand.
            window.Console.Write("Enter an integer: ");
            memory[operand] = window.Read();

            // Increment the program counter.
            pc++;
        }

        public override void Store(ref int pc)
        {
            int operand = memory[pc] % 100;

            // Read an integer from the Accumilator.Instance.Value, and store it in a memory location based on the operand.
            memory[operand] = Accumilator.Instance.Value;

            // Increment the program counter.
            pc++;
        }

        public override void Write(ref int pc)
        {
            int operand = memory[pc] % 100;

            // Read an integer from a memory location based on the operand, and print it.
            window.Console.WriteLine(memory[operand].ToString());

            // Increment the program counter.
            pc++;
        }
    }
}
