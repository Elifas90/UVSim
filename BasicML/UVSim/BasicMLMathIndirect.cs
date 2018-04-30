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
    /// Indirect implementations of BasicML Math Module
    /// </summary>
    public class BasicMLMathIndirect : BasicMLMath
    {
        public BasicMLMathIndirect(IUVSimController w, MemoryManager m) : base(w, m)
        {
        }

        public override void Add(ref int pc)
        {
            // Get operand from dword
            int operand = ComposeWORD(ref pc);

            // Add an integer from a memory location based on the operand to the Accumilator.Instance.Value.
            int value = ComposeDWORD(ref operand);
            Accumilator.Instance.Value = alu.Add(Accumilator.Instance.Value, value);

            // Increment the program counter.
            pc++;
        }

        public override void Divide(ref int pc)
        {
            // Get operand from dword
            int operand = ComposeWORD(ref pc);

            // Devide Accumilator.Instance.Value by the integer in a memory location based on the operand.
            int value = ComposeDWORD(ref operand);
            Accumilator.Instance.Value = alu.Divide(Accumilator.Instance.Value, value);

            // Increment the program counter.
            pc++;
        }

        public override void Exponential(ref int pc)
        {
            // Get operand from dword
            int operand = ComposeWORD(ref pc);

            // Raise the number in the Accumilator.Instance.Value to the power of the number in memory location specified by the operand.
            int value = ComposeDWORD(ref operand);
            Accumilator.Instance.Value = alu.Exponential(Accumilator.Instance.Value, value);

            // Increment the program counter.
            pc++;
        }

        public override void Multiply(ref int pc)
        {
            // Get operand from dword
            int operand = ComposeWORD(ref pc);

            // Multiply the integer in a memory location based on the operand by the integer in the Accumilator.Instance.Value.
            int value = ComposeDWORD(ref operand);
            Accumilator.Instance.Value = alu.Multiply(Accumilator.Instance.Value, value);

            // Increment the program counter.
            pc++;
        }

        public override void Reminder(ref int pc)
        {
            // Get operand from dword
            int operand = ComposeWORD(ref pc);

            // Get the reminder of the number in the Accumilator.Instance.Value devided by a number in memory location specified by the operand.
            int value = ComposeDWORD(ref operand);
            Accumilator.Instance.Value = alu.Reminder(Accumilator.Instance.Value, value);

            // Increment the program counter.
            pc++;
        }

        public override void Subtract(ref int pc)
        {
            // Get operand from dword
            int operand = ComposeWORD(ref pc);

            // Subtract the integer in a memory location based on the operand from the Accumilator.Instance.Value.
            int value = ComposeDWORD(ref operand);
            Accumilator.Instance.Value = alu.Subtract(Accumilator.Instance.Value, value);

            // Increment the program counter.
            pc++;
        }
    }
}
