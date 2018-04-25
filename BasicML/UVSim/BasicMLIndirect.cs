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
            // Get operand from word
            int operand = ComposeWORD(ref pc);

            // Branch to a location in memory based on the operand.
            pc = operand;
        }

        public override void BranchNeg(ref int pc)
        {
            // Get operand from word
            int operand = ComposeWORD(ref pc);

            // If the integer in the Accumilator.Instance.Value is negative, branch to a location in memory based on the operand.
            if (Accumilator.Instance.Value < 0) pc = operand;

            // If not, increment the program counter.
            else pc++;
        }

        public override void BranchZero(ref int pc)
        {
            // Get operand from word
            int operand = ComposeWORD(ref pc);

            // If the integer in the Accumilator.Instance.Value is zero, branch to a location in memory based on the operand.
            if (Accumilator.Instance.Value == 0) pc = operand;

            // If not, increment the program counter.
            else pc++;
        }

        public override void Load(ref int pc)
        {
            // Get operand from dword
            int operand = ComposeDWORD(ref pc);

            int value = ComposeDWORD(ref operand);
            // Read an integer from a memory location based on the operand, and load it in the Accumilator.Instance.Value.
            Accumilator.Instance.Value = value;

            // Increment the program counter.
            pc++;
        }

        public override void Read(ref int pc)
        {
            // Get operand from word
            int operand = ComposeWORD(ref pc);

            // Read an integer from the keyboard, and store it in a memory location based on the operand.
            window.Console.Write("Enter an integer: ");
            int value = window.Read();
            SaveDWORD(operand, value);

            // Increment the program counter.
            pc++;
        }

        public override void Store(ref int pc)
        {
            // Get operand from word
            int operand = ComposeWORD(ref pc);

            // Read an integer from the Accumilator.Instance.Value, and store it in a memory location based on the operand.
            SaveDWORD(operand, Accumilator.Instance.Value);

            // Increment the program counter.
            pc++;
        }

        public override void Write(ref int pc)
        {
            // Get operand from word
            int operand = ComposeWORD(ref pc);

            // Read an integer from a memory location based on the operand, and print it.
            int value = ComposeDWORD(ref operand);
            window.Console.WriteLine(value.ToString());

            // Increment the program counter.
            pc++;
        }
    }
}
