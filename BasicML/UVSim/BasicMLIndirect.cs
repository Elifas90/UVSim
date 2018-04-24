using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVSim
{
    //-----------------------------------------------------------------------------------------------------------------------
    //  File Designed by: Ali Alabdlmohsen

    // Implementation file for the "BasicMLIndirect" class.

    /// <summary>
    /// Indirect implementations of BasicML Module
    /// </summary>
    public class BasicMLIndirect : BasicML
    {
        public BasicMLIndirect(IUVSimController w, MemoryManager m) : base(w, m)
        {
        }

        public override void Branch(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];

            // Branch to a location in memory based on the operand.
            pc = operand;
        }

        public override void BranchNeg(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];

            // If the integer in the Accumilator.Instance.Value is negative, branch to a location in memory based on the operand.
            if (Accumilator.Instance.Value < 0) pc = operand;

            // If not, increment the program counter.
            else pc++;
        }

        public override void BranchZero(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];

            // If the integer in the Accumilator.Instance.Value is zero, branch to a location in memory based on the operand.
            if (Accumilator.Instance.Value == 0) pc = operand;

            // If not, increment the program counter.
            else pc++;
        }

        public override void Load(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];

            // Read an integer from a memory location based on the operand, and load it in the Accumilator.Instance.Value.
            Accumilator.Instance.Value = memory[operand];

            // Increment the program counter.
            pc++;
        }

        public override void Read(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];

            // Read an integer from the keyboard, and store it in a memory location based on the operand.
            window.Console.Write("Enter an integer: ");
            memory[operand] = window.Read();

            // Increment the program counter.
            pc++;
        }

        public override void Store(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];

            // Read an integer from the Accumilator.Instance.Value, and store it in a memory location based on the operand.
            memory[operand] = Accumilator.Instance.Value;

            // Increment the program counter.
            pc++;
        }

        public override void Write(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];

            // Read an integer from a memory location based on the operand, and print it.
            window.Console.WriteLine(memory[operand].ToString());

            // Increment the program counter.
            pc++;
        }
    }
}
