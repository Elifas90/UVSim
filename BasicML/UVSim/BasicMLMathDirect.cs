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
    /// Direct implementations of BasicML Math Module
    /// </summary>
    public class BasicMLMathDirect : BasicMLMath
    {
        public BasicMLMathDirect(IUVSimController w, MemoryManager m) : base(w, m)
        {
        }

        public override void Add(ref int pc)
        {
            int operand = memory[pc] % 100;

            // Add an integer from a memory location based on the operand to the Accumilator.Instance.Value.
            int value = ComposeDWORD(ref operand);
            Accumilator.Instance.Value = alu.Add(Accumilator.Instance.Value, value);

            // Increment the program counter.
            pc++;
        }

        public override void Divide(ref int pc)
        {
            int operand = memory[pc] % 100;

            // Devide Accumilator.Instance.Value by the integer in a memory location based on the operand.
            int value = ComposeDWORD(ref operand);
            Accumilator.Instance.Value = alu.Divide(Accumilator.Instance.Value, value);

            // Increment the program counter.
            pc++;
        }

        public override void Exponential(ref int pc)
        {
            int operand = memory[pc] % 100;

            // Raise the number in the accumilator to the power of the number in memory location specified by the operand.
            int value = ComposeDWORD(ref operand);
            Accumilator.Instance.Value = alu.Exponential(Accumilator.Instance.Value, value);

            // Increment the program counter.
            pc++;
        }

        public override void Multiply(ref int pc)
        {
            int operand = memory[pc] % 100;

            // Multiply the integer in a memory location based on the operand by the integer in the Accumilator.Instance.Value.
            int value = ComposeDWORD(ref operand);
            Accumilator.Instance.Value = alu.Multiply(Accumilator.Instance.Value, value);

            // Increment the program counter.
            pc++;
        }

        public override void Reminder(ref int pc)
        {
            int operand = memory[pc] % 100;

            // Get the reminder of the number in the accumilator devided by a number in memory location specified by the operand.
            int value = ComposeDWORD(ref operand);
            Accumilator.Instance.Value = alu.Reminder(Accumilator.Instance.Value, value);

            // Increment the program counter.
            pc++;
        }

        public override void Subtract(ref int pc)
        {
            int operand = memory[pc] % 100;

            // Subtract the integer in a memory location based on the operand from the Accumilator.Instance.Value.
            int value = ComposeDWORD(ref operand);
            Accumilator.Instance.Value = alu.Subtract(Accumilator.Instance.Value, value);

            // Increment the program counter.
            pc++;
        }
    }
}
