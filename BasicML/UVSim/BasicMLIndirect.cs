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
    public class BasicMLIndirect : BasicML
    {
        public BasicMLIndirect(IUVSimController w, MemoryManager m) : base(w, m)
        {
        }

        public override void Add(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];

            // Add an integer from a memory location based on the operand to the Accumilator.Instance.Value.
            Accumilator.Instance.Value = alu.Add(Accumilator.Instance.Value, memory[operand]);

            // Increment the program counter.
            pc++;
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

        public override void Divide(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];

            // Devide Accumilator.Instance.Value by the integer in a memory location based on the operand.
            Accumilator.Instance.Value = alu.Divide(Accumilator.Instance.Value, memory[operand]);

            // Increment the program counter.
            pc++;
        }

        public override void Exponential(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];
            // Raise the number in the Accumilator.Instance.Value to the power of the number in memory location specified by the operand.
            Accumilator.Instance.Value = alu.Exponential(Accumilator.Instance.Value, memory[operand]);

            // Increment the program counter.
            pc++;
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

        public override void Multiply(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];

            // Multiply the integer in a memory location based on the operand by the integer in the Accumilator.Instance.Value.
            Accumilator.Instance.Value = alu.Multiply(Accumilator.Instance.Value, memory[operand]);

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

        public override void Reminder(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];

            // Get the reminder of the number in the Accumilator.Instance.Value devided by a number in memory location specified by the operand.
            Accumilator.Instance.Value = alu.Reminder(Accumilator.Instance.Value, memory[operand]);

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

        public override void Subtract(ref int pc)
        {
            // Increment the program counter to get to the operand.
            pc++;
            int operand = memory[pc];

            // Subtract the integer in a memory location based on the operand from the Accumilator.Instance.Value.
            Accumilator.Instance.Value = alu.Subtract(Accumilator.Instance.Value, memory[operand]);

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
